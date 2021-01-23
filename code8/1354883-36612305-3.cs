    HttpPostedFile postedFile = imgFile.PostedFile;
    string fileExtension = Path.GetExtension(postedFile.FileName);
     if (fileExtension.ToLower() == ".jpg" || fileExtension.ToLower() == ".png")
     {
                Stream stream = postedFile.InputStream;
                BinaryReader reader = new BinaryReader(stream);
                byte[] imgByte = reader.ReadBytes((int)stream.Length);
         SqlCommand cmd = new Sqlcommand("INSERT INTO tableName(Image) VALUES(@img)",yourConnectionStringHere);
    cmd.Parameters.Add("@img",SqlDbType.VarBinary).Value = imgByte;
         cmd.ExecuteNonQuery();
     }
