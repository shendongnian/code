    public class Data
    {
        public string Color { get; set; }
        public string Name { get; set; }
    }
    [HttpPost]
    public PDF Post(List<Data> data) 
    {
        ... 
    }
