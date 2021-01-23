    var obj = JsonConvert.DeserializeObject<RootObject>(searchResult);
---
    public class Search
    {
        public string Title { get; set; }
        public string Year { get; set; }
        public string imdbID { get; set; }
        public string Type { get; set; }
    }
    public class RootObject
    {
        public List<Search> Search { get; set; }
    }
