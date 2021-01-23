    void WalkDirectoryTree(System.IO.DirectoryInfo root)
    {
        try
        {
            FileInfo[] files = root.GetFiles("*.cs");
            foreach(FileInfo fileInfo in files) 
            {
                int Vara = File.ReadAllText(fileInfo.FullName).Contains("namespace") ? 1 : 0;
                // do something with Vara
            }
        }
        catch (UnauthorizedAccessException e)
        {
        }
        catch (System.IO.DirectoryNotFoundException e)
        {
            Console.WriteLine(e.Message);
        }    
    }
