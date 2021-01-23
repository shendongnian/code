    using System.Collections.Generic;
    using System.Linq;
    
    
        public class SkiLodge
        {
            public static Dictionary<string, Skier> Skiers = new Dictionary<string, Skier>();
    
            static int income;
    
            string lodgeName;
    
            public SkiLodge(string newLodgeName)
            {
                this.lodgeName = newLodgeName;
            }
    
            static int newNumber = 1;
            //ADD SKIER
            public Skier AddSkier(string inName, string inAddress, int inScore)
            {
                string newNumberString = newNumber.ToString();
                newNumber = newNumber + 1;
                Skier skier= new Skier(newNumberString, inName, inAddress, inScore);
                Skiers.Add(newNumberString, skier);
                income = income + 100;
                return skier;
            }
    
            public List<Skier> FetchTopThree()
            {
                return Skiers.Values.OrderByDescending(s => s.InScore).Take(3).ToList();
            }
        }
    
        public class Skier
        {
            public string NewNumberString { get; }
            public string InName { get; }
            private readonly string inAddress;
            public int InScore { get; }
    
            public Skier(string newNumberString, string inName, string inAddress, int inScore)
            {
                this.NewNumberString = newNumberString;
                this.InName = inName;
                this.inAddress = inAddress;
                this.InScore = inScore;
            }
        }
