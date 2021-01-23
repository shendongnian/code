        byte[] bytes = new byte[17];
        using (IO.FileStream fs = new IO.FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)) {
    	fs.Read(bytes, 0, 16);
        }
        string chkStr = System.Text.ASCIIEncoding.ASCII.GetString(bytes);
        return chkStr.Contains("SQLite format");
