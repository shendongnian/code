    public class MyClass
    {
        [Import("MajorRevision")]
        public int MajorRevision { get; set; }
    }
    
    public class MyExportClass
    { 
        [Export("MajorRevision")] //This one will match.
        public int MajorRevision = 4;
    
        [Export("MinorRevision")]
        public int MinorRevision = 16;
    }
