    public List<string> FindLines(string DirName)
    {
        List<string> findLines = new List<string>();
        DirectoryInfo di = new DirectoryInfo(DirName);
        if(di != null && di.Exists) 
        {
            foreach(FileInfo fi in di.EnumerateFiles("*", SearchOption.AllDirectories))
            {
                //Debug.WriteLine(fi.Extension);
                //Debug.WriteLine(fi.FullName);
                if (   string.Compare(fi.Extension, ".cs", true)  == 0 
                    || string.Compare(fi.Extension, ".txt", true) == 0
                    || string.Compare(fi.Extension, ".txt", true) == 0)
                {
                    //findLines.Add(fi.FullName);
                    using (StreamReader sr = fi.OpenText())
                    {
                        string s = "";
                        while ((s = sr.ReadLine()) != null)
                        {
                            if (s.Contains("setting"))
                                findLines.Add(s);
                        }
                    }
                }
            }
        }
        return findLines;
    }
 
