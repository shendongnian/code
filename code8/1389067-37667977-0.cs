     public class TermData
     {
         //use if nessassry [JsonProperty("TermId")]
         public string TermId {get;set;}
     }
     [HttpGet]
     public List<string> getClassListByTerm([FromUri]TermData data)
