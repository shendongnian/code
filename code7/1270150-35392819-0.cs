    [WebMethod]
    public void UploadFile()
    {
        FileResponse master = new FileResponse();
        //HTTP Context to get access to the submitted data
        HttpContext postedContext = HttpContext.Current;
        //File Collection that was submitted with posted data
        HttpFileCollection Files = postedContext.Request.Files;
        string sessionId = Server.UrlDecode((string)postedContext.Request.Form["sessionId"]);
        master.sessionId = sessionId;
        master.timeStamp = DateTime.Now.DdMonYyyy_HhMmSs();
        master.status = Status.Failure;
        master.sessionStatus = Status.Failure;
        master.message = "Image not found";
        try
        {
            if (isGuest_Employee(sessionId))
            {
                //Make sure a file was posted
                string fileName = string.Format("feedbackImgSign_{0}.png", Helper.LDFileNumberSeq);
                if (Files.Count == 1 && Files[0].ContentLength >= 1)
                {
                    //The byte array we'll use to write the file with
                    byte[] binaryWriteArray = new
                    byte[Files[0].InputStream.Length];
                    //Read in the file from the InputStream
                    Files[0].InputStream.Read(binaryWriteArray, 0,
                    (int)Files[0].InputStream.Length);
                    //Open the file stream
                    FileStream objfilestream = new FileStream(Helper.UploadedFilesDirectory + "\\" +
                    fileName, FileMode.Create, FileAccess.ReadWrite);
                    //Write the file and close it
                    objfilestream.Write(binaryWriteArray, 0,
                    binaryWriteArray.Length);
                    objfilestream.Close();
                    master.FILE_NAME = fileName;
                    master.status = Status.Success;
                    master.sessionStatus = Status.Success;
                    master.message = "Image uploaded successfully!";
                }
            }
            else
            {
                master.status = Status.Failure;
                master.sessionStatus = Status.Failure;
                master.message = "Unable to authenticate provided session Id";
            }
        }
        catch (Exception ex)
        {
            master.status = Status.Failure;
            master.message = ex.Message;
        }
       string strJSON = JsonConvert.SerializeObject(master, Formatting.Indented,
               new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
        Context.Response.Clear();
        Context.Response.ContentType = "application/json";
        Context.Response.Write(strJSON);
    }
