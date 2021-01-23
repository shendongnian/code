    public FirstReadViewModel()
    {
            var dbFunctions = new DataLayer();
            this.ScriptNotes = dbFunctions.GetFirstReadNotes();
    } 
