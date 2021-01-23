    public void upload_image_file() 
    { 
      using (WebClient client = new WebClient())  
      { client.Credentials = new NetworkCredential("username", "p/w"); 
        client.UploadFile("FTP_PATH/YOUR FILE NAME.extention", "STOR", "where the local file stored/YOUR FILE NAME.extention"); 
      } 
    }
