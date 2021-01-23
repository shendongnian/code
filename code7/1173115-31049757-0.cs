    public class Voter
    {
        public string id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string date_of_birth { get; set; }
    }
    
    public class RootObject
    {
        public List<Voter> voters { get; set; }
    }
    var VoterModel = JsonConvert.DeserializeObject<List<Voter>>(json);
