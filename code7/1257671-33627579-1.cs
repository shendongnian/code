    public static object FileAccessLock = new object(); // Put this in a global area.
    
    lock(FileAccessLock)
    {
        string[] text = File.ReadAllLines(path);
        text[23] = "replacement";
        File.WriteAllLines(path, text);
    }
