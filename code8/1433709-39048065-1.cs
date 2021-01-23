    public FileResult Download()
    {
        var document = BusinessLayer.GetDocumentsByDocument(documentId, AuthenticationHandler.HostProtocol).FirstOrDefault();
        string fileName = document.FileName;
        return File(document.FileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
    }
