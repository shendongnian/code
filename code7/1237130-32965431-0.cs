    public static Assembly LoadAssembly(string filename)
    {
        var content = System.IO.File.ReadAllBytes(filename);
        return AppDomain.CurrentDomain.Load(content);
    }
