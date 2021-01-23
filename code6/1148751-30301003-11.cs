    public class ClassC
    {
        public int Id { get; set; }
    
        [DefaultValue("NOTSET")]
        public string SomeString { get; set; }
        public int? SomeInt { get; set; }
    
        public void Verify()
        {
            if (SomeInt == null ) throw new JsonSerializationException("SomeInt not set!");
            if (SomeString == "NOTSET") throw new JsonSerializationException("SomeString not set!");
        }
    }
