    public static void WriteLine(string fileName, string str) 
    {
        using (FileStream fs = new FileStream(fileName,FileMode.Append, FileAccess.Write, FileShare.Read))
        using (StreamWriter sw = new StreamWriter(fs))
        {
            sw.WriteLine(str);
        }
    }
