    public partial class Presentation : IDisposable
    {
      public Pa.PresentationDocument PresentationDoc { get; set; }   //PresentationPart parts
      private MemoryStream _MemStream { get; set; }
    
      public void Init(string FileName = "NoName")
      {
        //Init stream
        this._MemStream = new MemoryStream();
        this.PresentationDoc = Pa.PresentationDocument.Create(
          this._MemStream, PresentationDocumentType.Presentation);
        // Create the presentation
      }
      public string Save(string path)
      {
        this.PresentationDoc.Close();
        using (FileStream fileStream = new FileStream(FileTemp,
          System.IO.FileMode.CreateNew))
        {
          this._MemStream.WriteTo(fileStream);
        }
    
        this._MemStream.Flush();
      }
    
      public void Dispose()
      {
        if(_MemStream != null)
        {
          _MemStream.Dispose();
        }
      }
    }
