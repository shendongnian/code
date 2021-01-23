    public byte[] someProperty{get;set;}
    HttpPostedFile postedFile = imgFile.PostedFile;
    string fileExtension = Path.GetExtension(postedFile.FileName);
    
     if (fileExtension.ToLower() == ".jpg" || fileExtension.ToLower() == ".png")
     {
        Stream stream = postedFile.InputStream;
        BinaryReader reader = new BinaryReader(stream);
        byte[] imgByte = reader.ReadBytes((int)stream.Length);
     }
    someProperty = imgByte;
    Session["yourImg"] = someProperty;
