    public override void Flush() {
        ...
        var fileContents = GetLanguageFileContents();
        ...
    }
    private string GetLanguageFileContents(string languageName) {
        if (HttpRuntime.Cache[languageName] != null)
        {
            //Just pull it from memory!
            return (string)HttpRuntime.Cache[languageName];
        }
        else
        {
            //Take the IO hit  :(
            var fileContents = ReadFileFromDiskOrDatabase();
            //Store the data in memory to avoid future IO hits  :)
            HttpRuntime.Cache[languageName] = fileContents;
            return fileContents;
        }
    }
