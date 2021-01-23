    class BigDataClass
    {
        private List<string> data = new List<string>();
        public List<string> Data { get { return data; } } // note, we removed the setter
    }
    var bigData = new BigDataClass();
    bigData.Data.Add("Some String");
