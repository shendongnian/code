    public class Athlete
    {
        public string AthleteLastName { get; set; }
        public string AthleteFirstName { get; set; }
        public int Number { get; set; }
        public bool IsPresent { get; set; }
    }
    
    public class Stat
    {
        public bool InputKoffRetStats { get; set; }
        public bool InputPenaltyStats { get; set; }
        public List<Athlete> VisitingTeamFootballRbStats { get; set; }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            var jsonText = "{" +
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
    
            var stat = JsonConvert.DeserializeObject<Stat>(jsonText);
    
            Console.WriteLine(stat.VisitingTeamFootballRbStats[0].AthleteFirstName);
            Console.ReadKey();
        }
    }
