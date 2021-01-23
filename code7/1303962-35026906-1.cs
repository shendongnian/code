    Sftp sftp = new Sftp();
    sftp.Connect(...);
    sftp.Login(...);
    
    // upload the file
    sftp.PutFile(localFile, remoteFile);
    
    // assign creation and modification time attributes
    SftpAttributes attributes = new SftpAttributes();
    System.IO.FileInfo info = new System.IO.FileInfo(localFile);
    attributes.Created = info.CreationTime;
    attributes.Modified = info.LastWriteTime;
    
    // set attributes of the uploaded file
    sftp.SetAttributes(remoteFile, attributes);
    
