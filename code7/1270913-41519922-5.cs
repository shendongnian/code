        // write File in server side
        string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, DateTime.Now.ToString("yyyyMMddHHmmss"));
        
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        string filePath = Path.Combine(path, "FileName");
        File.WriteAllBytes(filePath , excelByte);
        // read file locally
        using (FileStream fileStream = new FileStream(filePath , FileMode.Open, FileAccess.Read))
        {
            // TO DO
        }
