    internal static void Download(string FileName)
    {
        HttpResponse _response = HttpContext.Current.Response;
        FileStream _fileStream;
        byte[] _arrContentBytes;
        try
        {
            // clear response obj
            _response.Clear();
    
            // clear content of response obj
            _response.ClearContent();
    
            // clear response headers
            _response.ClearHeaders();
    
            // enable response buffer
            _response.Buffer = true;
    
            // specify response content
            _response.ContentType = ContentType;
    
            _response.StatusCode = 206;
            _response.StatusDescription = "Partial Content";
    
            // create FileStream: IMPORTANT - specify FileAccess.Read
            _fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
    
            // Bytes array size= (int)_fs.Length;
            _arrContentBytes = new byte[(int)_fileStream.Length];
    
            // read file into bytes array
            _fileStream.Read(_arrContentBytes, 0, (int)_fileStream.Length);
    
            // add response header
            _response.AddHeader("content-disposition", "attachment;filename=" + FileName);
    
            // ACTUAL PROCEDURE: use BinaryWrite to download file
            _response.BinaryWrite(_arrContentBytes);
    
            // ALTERNATIVE: TransmitFile
            //_response.TransmitFile(filePath);
    
            // close FileStream
            _fileStream.Flush();
            _fileStream.Close();
    
            _response.Flush();
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
        catch { }
        finally
        {
            _fileStream = null;
            _arrContentBytes = null;
        }
    }
