    string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
    string filename = Path.Combine(path, "myfile.txt");
    using (var streamWriter = new StreamWriter(filename, true))
    {
         streamWriter.WriteLine(DateTime.UtcNow);
    }
    using (var streamReader = new StreamReader(filename))
    {
         string content = streamReader.ReadToEnd();
         System.Diagnostics.Debug.WriteLine(content);
    }
