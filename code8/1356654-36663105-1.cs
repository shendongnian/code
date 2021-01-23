    static Int64 FolderSize(string path)
    {
        long sum =0;
        try
        {
            // scan folders
            foreach(var dir in Directory.EnumerateDirectories(path))
            {
                //recursive call
                sum += FolderSize( dir);
            }
        } 
        catch(UnauthorizedAccessException unath)
        {
            Console.WriteLine("{0} for folder {1}", unath.Message, path);
        }
        try
        {
            // scan files
            foreach (var file in Directory.EnumerateFiles(path))
            {
                sum += new FileInfo(file).Length;
            }
        }
        catch(UnauthorizedAccessException filesec)
        {
            Console.WriteLine("{0} for file {1}", filesec.Message, path);
        }
        return sum;
    }
