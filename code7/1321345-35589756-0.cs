    var files = Directory.GetFiles(@"C:\Users", "*.*", SearchOption.AllDirectories);
    
    long totalSize = 0;
    foreach (string name in files)
    {
       var info = new FileInfo(name);
       totalSize += info.Length;
    }
    return totalSize;
