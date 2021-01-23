    public class ResultContent
    {
        public IList<Result> Results { get; set; }
    }
    public class Result
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
    var r = JsonConvert.DeserializeObject<ResultContent>(json);
