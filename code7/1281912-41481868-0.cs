    // File Loader
    public static class ReadJsonFile
    {
        public static string GetFileFromDisk(string path)
        {
            var absPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location); ;
            return File.ReadAllText(absPath + path);
        }
    }
    // Call the loader
    var resultString = ReadJsonFile.GetFileFromDisk("/TestData/data.json");
    JObject.Parse(resultString);
