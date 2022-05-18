using NotesApp.Models;

namespace NotesApp.Services;

public static class NoteService
{
  static List<Note> Notes { get; }
  static int nextId = 3;

  static NoteService()
  {
    Notes = new List<Note>()
    {
      new Note() { Id = 1, Content = "CSS is hard", Important = true },
      new Note() { Id = 2, Content = "HTML is easy", Important = false }
    };
  }

  public static List<Note> GetAll() => Notes;

  public static Note? Get(int id) => Notes
      .FirstOrDefault(n => n.Id == id);

  public static void Add(Note note)
  {
    note.Id = nextId++;
    Notes.Add(note);
  }

  public static void Update(Note note)
  {
    var index = Notes.FindIndex(n => n.Id == note.Id);
    if (index == -1)
      return;

    Notes[index] = note;
  }

  public static void Delete(int id)
  {
    var note = Get(id);
    if (note is null)
      return;

    Notes.Remove(note);
  }
}
