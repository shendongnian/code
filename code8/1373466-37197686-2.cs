    //Attach files
    foreach (var path in paths) {
        //For file information
        var fileInfo = new FileInfo(path);
        //stream to store attachment
        var memoryStream = new MemoryStream();
        //copy file from disk to memory
        using (var stream = fileInfo.OpenRead()) {
            stream.CopyTo(memoryStream);
        }
        //reset memory pointer
        memoryStream.Position = 0;
        //get file name for attachment based on path
        string fileName = fileInfo.Name;
        //add attachment to message
        message.Attachments.Add(new Attachment(memoryStream, fileName));
    }
     
