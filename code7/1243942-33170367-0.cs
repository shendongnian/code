    public class Responce
    {
        public string status{get;set;}
        public List<Result> results {get;set;}
    }
    ...
    var responce = JsonConvert.DeserializeObject<Responce>(Jsonstring);
    DoSomething(responce.results);
