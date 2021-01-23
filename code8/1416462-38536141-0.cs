    public static bool isSQLiteDatabase(string pathToFile)
    {
        bool result = false;
    
        System.IO.FileStream stream = new System.IO.FileStream(pathToFile, System.IO.FileMode.Open);
    
        byte[] header = new byte[16];
    
        for(int i = 0; i < 16; i++)
        {
            header[i] = (byte) stream.ReadByte();
        }
    
        result = System.Text.Encoding.UTF8.GetString(header).Contains("SQLite format 3");
    
        stream.Close();
    
        return result;
    }
