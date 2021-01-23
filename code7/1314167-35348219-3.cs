    public void closeDocument(Word.Document doc)
    {
        object missing = Missing.Value;
        object doNotSaveChanges = Word.WdSaveOptions.wdDoNotSaveChanges; 
        this.Close(ref doNotSaveChanges, ref missing, ref missing);           
    }
