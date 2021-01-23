    class HockeyPlayer
    {
     
        public string LastName {get; set;}
        public int JerseyNum {get; set;}
        public int Goals {get; set;}
        public HockeyPlayer(string lastName, int jerseyNumber, int goalsScored)
        {
            LastName = lastName;
            JerseyNum = jerseyNumber;
            Goals = goalsScored;
        }
    } 
