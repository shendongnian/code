     class jsonDeserialize
        {
            
            public List<DataList> data { get; set; }
            public Paging paging { get; set; }
    
        }
    
        public class DataList
        {
            public string id { get; set; }
        }
    
        public class Paging
        {
            public Cursors cursors { get; set; }
            public string next { get; set; }
        }
        public class Cursors
        {
            public string before { get; set; }
            public string after { get; set; }
        }
    
    var result=JsonConvert.DeserializeObject<jsonDeserialize>(jsonformat.Substring(0,jsonformat.Length));
