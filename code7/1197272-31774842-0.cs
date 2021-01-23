    public class ResFile
    {
        public string hash { set; get; }
        public int size { set; get; }
    }
    public class ResRoot
    {
        public Dictionary<string, ResFile> Files { set; get; }
    }
