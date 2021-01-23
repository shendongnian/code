    internal class RootObject
    {
        public string success { get; set; }
        public string message { get; set; }
        public string total { get; set; }
        public List<Sponsorise> sponsorises { get; set; }
    }
    
    class Sponsorise
    {
        public string nom { get; set; }
    
        public string tel { get; set; }
    
        public string photo { get; set; }
    
        public string sponsorise_adrs { get; set; }
    }
