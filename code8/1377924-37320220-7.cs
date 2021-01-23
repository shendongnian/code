    public void makeChangesAndSaveDocX(DocX wordDoc)
    {
       try
       {
           wordDoc.Save();
       }
       finally
       {
          ((IDisposable)wordDoc).Dispose();
       }
    } 
