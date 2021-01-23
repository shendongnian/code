    var file = fuAttachment.PostedFile;
                if (file != null && fuAttachment.PostedFile.FileName != "")
                {
                    var content = new byte[file.ContentLength];
                    file.InputStream.Read(content, 0, content.Length);
                    List<MyFile> myUploadedFiles = null;
    
                    if(Session["UploadedFiles"] == null)
                    {
                        myUploadedFiles = new List<MyFile>();
                    }
                    else
                    {
                        myUploadedFiles = (List<MyFile>)Session["UploadedFiles"];
                    }
    
                    myUploadedFiles.Add(new MyFile()
                    {
                        Content = content,
                        ContentType = file.ContentType,
                        Name = file.FileName
                    });
    
                    Session["UploadedFiles"] = myUploadedFiles;
                }
                else
                {
                    Session["UploadedFiles"] = null;
                }
