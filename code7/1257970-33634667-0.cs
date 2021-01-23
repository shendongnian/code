    public class Player
        {
            public class Statistics
            {
                public int STR;
                public int INT;
                public int DEX;
                public int VIT;
            }
            public Player()
            {
                this.Stats = new Player.Statistics()
                {
                    STR = 1,
                    INT = 1,
                    DEX = 1,
                    VIT = 1
                };
            }
            public Statistics Stats {get;set;}
            
        }
