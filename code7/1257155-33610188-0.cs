    public string fileName { get; set; }
    public bool WriteToFile()
    {        
        try
        {
            using (System.IO.StreamWriter WriteToFile = new System.IO.StreamWriter(fileName))
            {
                WriteToFile.Write(text);
                WriteToFile.Close();
            }
            return true;
        }
        catch
        {
            return false;
        }
    }
}
