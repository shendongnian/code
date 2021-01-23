    public void AddNote(Note addnote)
    {
        collection.Add(note);
        Console.WriteLine("Note has been added!\n");
        foreach (var element in collection)
        {
            Console.WriteLine("Note is: " + element.Note + " = priority" + element.Priority);
        }
    }
