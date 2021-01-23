    public void WriteToFile()
    {
        using (var fileWriter= new System.IO.StreamWriter(FileName))
        {
            fileWriter.Write(_text);
            fileWriter.Close();
        }
    }
