    public class Export
    {
        public Info info { get; set; }
    }
    public class Info
    {
        public DateTime exportDateTime { get; set; }
        public int duration { get; set; }
        public VersionedName planningSoftware { get; set; }
        public Exporter exporter { get; set; }
    }
    public class Exporter
    {
        public VersionedName version { get; set; }
        public VersionedName module { get; set; }
    }
