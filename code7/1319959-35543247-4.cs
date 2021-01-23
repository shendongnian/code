    class Box
    {
        List<Note> collection = new List<Note>();
        public AddNote(Note note)
        {
            Collection.Add(addnote);
            Console.WriteLine("Note has been added!\n");
            foreach (var element in collection)
            {
                Console.WriteLine("Note is: " + element.Note + " = priority" + element.Priority);
            }
        }
    }            
    
