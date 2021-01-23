    [HttpPost]
    public PartialViewResult GetResults(QueryScreen screen)
    {
        RuleOrGroup query = (RuleOrGroup)Newtonsoft.Json.JsonConvert.DeserializeObject(screen.Query, typeof(RuleOrGroup));
         //do some stuff return a view.
    }
    public class RuleOrGroup
    {
        //Fields if it's a group
        public string condition { get; set; }
        public List<RuleOrGroup> rules { get; set; }
        //Fields if it's a Rule
        public string id { get; set; }
        public string field { get; set; }
        public FilterType type { get; set; }
        public string input { get; set; }
        public FilterOperators @operator { get; set; }
        public string value { get; set; }
        
        public bool IsAGroup { get { return condition != null; } }
    }
