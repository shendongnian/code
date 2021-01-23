    public Stream GetMultimedia(string id)
    { 
        string filePath = MultimediaBLL.GetFilePath(int.Parse(id));
        if (string.IsNullOrEmpty(filePath))
            return null;
        try
        {
            FileStream multimediaFileStream = File.OpenRead(filePath);
            WebOperationContext.Current.OutgoingResponse.ContentType = "Your/contentType";
            WebOperationContext.Current.OutgoingResponse.Headers["Content-Disposition"] = "attachment; filename=Your_file_name.png";
            return multimediaFileStream;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Not able to get multimedia stream:{0}", ex.Message);
            throw ex;
        }
    }
