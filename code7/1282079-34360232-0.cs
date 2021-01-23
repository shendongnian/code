    public static void moveFiles(string source, string destination)
    {
        ...
    }
    public static void moveFiles()
    {
        moveFiles(ConfigurationManager.AppSettings["RootLoc"],
                  ConfigurationManager.AppSettings["DropBoxLocation"]);
    }
