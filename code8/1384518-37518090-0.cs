    public static void WriteToFile(string s, string fileName)
    {
        string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
        fs = new System.IO.FileStream(path, System.IO.FileMode.Append, System.IO.FileAccess.Write);
        sw = new System.IO.StreamWriter(fs);
        sw.WriteLine(s);
        sw.Flush();
        sw.Close();
        fs.Close();
    }
