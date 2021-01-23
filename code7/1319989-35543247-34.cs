    public static void Test()
    {
        NotifyingBox box = new NotifyingBox();
        box.NoteAdded += Box_NoteAdded;
        box.AddNote(new Note { Text = "aaa", Priority = 1 });
        box.AddNote(new Note { Text = "bbb", Priority = 2 });
    }
    private static void Box_NoteAdded(NotifyingBox box)
    {
        Console.WriteLine();
        Console.WriteLine("Note has been added!");
        foreach (Note note in box.Notes) {
            Console.WriteLine($"  Note is: {note.Text} = priority{note.Priority}");
        }
    }
