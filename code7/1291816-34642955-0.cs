    public class HistoClass
    {
        public string date; 
        [JsonProperty(NullValueHandling=NullValueHandling.Ignore)]
        public int? value1;
        [JsonProperty(NullValueHandling=NullValueHandling.Ignore)]
        public int? value2;
    }
    ...
    List <Models.HistoClass> HistoData= new List<Models.HistoClass>();
    HistoData.Add(new Models.HistoClass {date="bla",value1="bla1",value2="bla3"});
    HistoData.Add(new Models.HistoClass { date= "blx", value2="blax2" });
