    get
    {
    string dirName =System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        string pathName;
        DirectoryInfo d = new DirectoryInfo("TradeBotData");
        if (!d.Exists)
        {
            if (d.Parent.Name.ToString() == "Plugins")
            {
                d.Create();
                return d.FullName;
            }
         //////////HERE///////
        }
        else
        {
            if (d.Parent.Name.ToString() == "Plugins")
            {
                return d.FullName;
            }
            else
            { 
                Console.WriteLine("Data path Fallback!!!");
                pathName = System.IO.Path.Combine(dirName, @"\TradeBotData");
                System.IO.Directory.CreateDirectory(pathName);
                Console.WriteLine("Created Save Folder At: {0} :", pathName);
                return pathName;
            }
        }
    }
