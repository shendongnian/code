    PDFUtility.Document docFinal = new PDFUtility.Document();
    PDFUtility.Document docToAdd = byte[] combinedFile;
    List<MemoryStream> streams = new List<MemoryStream>();
    try 
    {
        foreach (byte[] content in fileContents)
        {
            MemoryStream fileContentStream = new MemoryStream(content);
            streams.Add(fileContentStream); //EACH INSTANCE OF A STREAM IS TRACKED
            docToAdd = new PDFUtility.Document(fileContentStream);
            docFinal.Pages.AddRange(docToAdd.Pages.CloneToArray());
        }
        using (MemoryStream stream = new MemoryStream())
        {
            docFinal.Write(stream);
            combinedFile = stream.ToArray();
        }
    
    }
    finally 
    {
        streams.ForEach(s => s.Dispose()); //DISPOSE OF ALL STREAMS HERE
    }
        
