    public String UploadCustomFile(string fileName, System.IO.Stream stream)
    {
        string FilePath =  Path.Combine(HostingEnvironment.MapPath("~/FileServer/Uploads"), fileName);
        int length = 0;
        using (FileStream writer = new FileStream(FilePath, FileMode.Create))
        {
            int readCount;
            var buffer = new byte[8192];
            while ((readCount = stream.Read(buffer, 0, buffer.Length)) != 0)
            {
                writer.Write(buffer, 0, readCount);
                length += readCount;
            }
        }
        return "okey";
        }
