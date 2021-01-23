    using System;
    using System.Collections.Generic;
    
    namespace Test
    {
        class Bet
        {
            public string Match { get; set; }
            public string Result { get; set; }
            public List<string> Odds { get; set; }
            public string Date { get; set; }
            public string Home { get; set; }
            public string Host { get; set; }
            public int HomePoints { get; set; }
            public int HostPoints { get; set; }
        public Bet()
        {
            Odds = new List<string>();
        }
        public override string ToString()
        {
            String MatchInfo = String.Format("{0}: {1} -> {2}", Date, Match, Result);
            String OddsInfo = String.Empty;
            foreach (string d in Odds)
                OddsInfo += " | " + d;
            return MatchInfo + "\n" + OddsInfo;
        }
    }
    }
