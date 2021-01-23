    public class ChuckNorris
    {
        public string Kick { get; set; }
        public string Punch { get; set; }
    }
    
    var cn = new ChuckNorris
    {
        Kick = "Dead",
        Punch = Kick
    };
