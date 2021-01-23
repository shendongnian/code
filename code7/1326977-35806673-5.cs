    static void Main(string[] args)
    {
        bool useThirdPartyLoader = GetInfoFromConfig();
        IFileLoader loader = FileLoaderFactory.Create(useThirdPartyLoader);
        var files = GetFilesFromSomewhere();
        ProcessFiles(loader, files);
    }
    public static class FileLoaderFactory
    {
        public static IFileLoader Create(bool useThirdPartyLoader)
        {
            if (useThirdPartyLoader)
            {
                return new ThirdPartyLoader();
            }
            
            return new SmartLoader(new StatusSetter());
        }
    }
