    class TopClass
    {
        public TopClass()
        {
            ClsProp3 = new SubClass();
        }
        public string ClsProp1 { get; set; }
        public string ClsProp2 { get; set; }
    
        public SubClass ClsProp3 { get; set; }
    }
