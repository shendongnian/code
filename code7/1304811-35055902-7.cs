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
    uploadedFileList.DataSource = myUploadedFiles;
    uploadedFileList.DataBind();
    protected void lkbCommandAction_Command(object sender, CommandEventArgs e) 
        {
            if (e.CommandArgument == null)
            {
                /*TODO*/
            }
            else 
            {
                List<MyFile> myUploadedFiles = null;
    
                    if(Session["UploadedFiles"] == null)
                    {
                        myUploadedFiles = new List<MyFile>();
                    }
                    else
                    {
                        myUploadedFiles = (List<MyFile>)Session["UploadedFiles"];
                    }
                    Guid removeId= (Guid)e.CommandArgument;
                    MyFile fileToRemove = myUploadedFiles.FIrstOrDefault(ff => ff.Id == removeId);
                    if(fileToRemove != null)
                    {
                         myUploadedFiles.Remove(fileToRemove);
                    }
                    uploadedFileList.DataSource = myUploadedFiles;
                    uploadedFileList.DataBind();
            }
        }
