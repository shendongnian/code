    namespace traditional_poker
    {
        public class poker
        {
           public class hand // use PascalCaseNamingConvention
            {
               public String Name
                {
                    get; set;
                }
               public String[] cards // use PascalCaseNamingConvention
                {
                    get; set;
                }
    
            }
    
            List<hand> players;
    
            public void AddPlayer(String name)
            {
                hand newHand = new hand();
                newHand.Name = name;
                players.Add(newHand); //null reference exception here! you should initialize players
            }
        }
    }
