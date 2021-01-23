    private void ProcessFiles(object e)
    {
        try
        {
            var diectoryPath = _Configurations.Descendants().SingleOrDefault(Pr => Pr.Name == "DirectoryPath").Value;
            var FilePaths = Directory.EnumerateFiles(diectoryPath);
            Parallel.ForEach(FilePaths, path => this.ProcessFile(path));
        }
        catch (Exception ex)
        {
            throw;
        }
    }
