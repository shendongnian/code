            public class MovementChartViewModel
            {
                public MovementChartViewModel()
                {
                    Categories = new List<string>();
                    Leaving = new List<int>();
                    Arriving = new List<int>();
                }
    
                public List<string> Categories { get; set; }
                public List<int> Leaving { get; set; }
                public List<int> Arriving { get; set; }
            }
    
            public class MovementObject
            {
                public int MovementId {get;set;}
                public string MovedFrom {get;set;}
                public string MovedTo { get; set; }  
            }
