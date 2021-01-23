    var blob = repo.Head.Tip[{FilePathToContentFrom}].Target as Blob;
    using (var content = new StreamReader(blob.GetContentStream(), Encoding.UTF8))
    {
       commitContent = content.ReadToEnd();
    }
