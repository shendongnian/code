    public class MyDirectory
    {
        public string Path { get; set; }
        public IEnumerable<MyDirectory> MyDirectories { get; set; }
    }
    private static IEnumerable<MyDirectory> DirSearch(string directory)
    {
        return Directory.EnumerateDirectories(directory).Select(l => new MyDirectory
        {
            Path = l,
            MyDirectories = DirSearch(l)
        });
    }
