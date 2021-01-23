    class SomeDTO
    {
        [Position(0,12)]
        public string SomeString { get; set; }
        [Position(13, 20)]
        public int SomeInt { get; set; }
        [Position(21-25)]
        public bool SomeBool { get; set; }
    }
