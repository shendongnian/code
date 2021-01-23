    private IENumerable<string> ReadLine(string path)
    {
        var file = OpenFile(path);
        while (file.Read())
        {
            yield return file.GetLine();
        }
        file.Close();
    }
