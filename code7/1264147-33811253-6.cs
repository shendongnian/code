    public abstract class VersionBase<T>
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public abstract T Weird { get; set; }
        public MysteriousDad Mysterious { get; set; }
    }
