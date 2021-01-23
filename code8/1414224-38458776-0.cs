    using(var stream = new System.IO.MemoryStream())
    {
        if (!File.Exists(Path.GetTempPath() + "ImageNotFound.jpg"))
        {
            using(FileStream file = new FileStream(Path.GetTempPath() + "ImageNotFound.jpg", FileMode.Create, FileAccess.Write))
            {
                ss.Save(stream, ImageFormat.Jpeg);
                stream.Position = 0;
                stream.WriteTo(file);
            }
        }
    }
