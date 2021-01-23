    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    
    namespace ConsoleApplication3
    {
        class Program
        {
            static void Main(string[] args)
            {
               var team=  "{" +
                           "    \"InputKoffRetStats\":true,\"InputPenaltyStats\":false," +
                           "    \"VisitingTeamFootballRbStats\":" +
                           "         [{" +
                           "             \"AthleteLastName\":\"John\"," +
                           "             \"AthleteFirstName\":\"Smith\",\"Number\":9,\"IsPresent\":true" +
                           "         }," +
                           "         {" +
                           "             \"AthleteLastName\":\"Justin\"," +
                           "             \"AthleteFirstName\":\"Brooks\",\"Number\":10,\"IsPresent\":false" +
                           "         }]" +
                           "}";
    
                
                var desTeam = JsonConvert.DeserializeObject<Team>(team);  
                Console.WriteLine(desTeam.VisitingTeamFootballRbStats[0].AthleteFirstName);
    
    
            }
        }
    
        public class Team{
            public bool InputKoffRetStats { get; set; }
            public bool InputPenaltyStats { get; set; }
            public  List<AthleteInfo> VisitingTeamFootballRbStats { get; set; }
    
        }
    
        public class AthleteInfo
        {
            public string AthleteLastName { get; set; }
            public string AthleteFirstName { get; set; }
            public string Number { get; set; }
            public bool IsPresent { get; set; }
        }
    }
