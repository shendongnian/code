    class Foo
    {
        private string _bar;
        public string Bar
        {
            get { return _bar; }
            set
            {
                _bar = value;
                BarSpecified = true;
            }
        }
    
        [JsonIgnore]
        public bool BarSpecified { get; set; }
    }
