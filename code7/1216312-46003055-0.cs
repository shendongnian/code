    string input;
    var myNotes = new List<Note>();
    do{
        input = Console.ReadLine();
        if (!input.Equals("exit", StringComparison.OrdinalIgnoreCase)){
            var note = new Note();
            note.addText(input);
            myNotes.Add(note);
        }
    } while (!input.Equals("exit", StringComparison.OrdinalIgnoreCase));
