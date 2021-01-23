    public void closeDocument(Word.Document doc)
    {
        object missing = Missing.Value;
        doc.Close(ref missing, ref missing, ref missing);
    }
