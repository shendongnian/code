    string FileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
    string Extension = Path.GetExtension(FileUpload1.PostedFile.FileName);
    //This setting get from configuration file 
    string FolderPath =ConfigurationManager.AppSettings("UploadFolder").ToString();
    string FilePath = Server.MapPath(FolderPath + "\\" + FileName);
    //Save file  
    FileUpload1.SaveAs(FilePath);
    string conStr = "";
    switch (Extension)
    {
       case ".xls": //Excel 97-03
                    conStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=Excel 12.0;";
                    break;
       case ".xlsx": //Excel 07
                    conStr = "Provider=Microsoft.ACE.OLEDB.12.0 ;Data Source={0};Extended Properties=\"Excel 12.0 Xml;IMEX=1;HDR=NO\";";
                   
                    break;
            }
           conStr = String.Format(conStr, FilePath);
          
