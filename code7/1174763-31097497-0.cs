    public static bool PathsSame(string pth1, string pth2)
    {
        
        string fName = System.IO.Path.GetRandomFileName();
        string fPath = System.IO.Path.Combine(pth1, fName);
        System.IO.File.Create(fPath);
        string nPath = System.IO.Path.Combine(pth1, fName);
        bool same = File.Exists(nPath);
        System.IO.File.Delete(fPath);
        return same;
    }
