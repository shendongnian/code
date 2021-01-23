    public List<Directory> GetDirectories()
    {
        var dirs = new List<Directory>();
        for (var ch = 'A'; ch <= 'Z'; ch++)
        {
            var url = string.Format(
                "<a href='/Directories/?search={0}' rel='{0}'>", ch);
            dirs.Add(new Directory() { Character = ch, Url = url });
        }
        return dirs;
    }
    // Directory class is simplifed a bit in this example
    public class Directory
    {
        public char Character { get; set; }
        public string Url { get; set; }
    }
