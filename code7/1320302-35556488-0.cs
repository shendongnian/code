    public void SaveNotes()
    {
        using (StreamWriter save= new StreamWriter("notes.txt", true))
        {               
            foreach (var element in collection)
            {
                if (element.Prio.IndexOf('\0') < 0 && element.Note.IndexOf('\0') < 0)
                    spara.Write(element.Prio+ " " + element.Note+ "\n");
                else spara.Write(" \n");
            }
        }
    }
