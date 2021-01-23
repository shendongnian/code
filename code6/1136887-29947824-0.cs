       class Program
        {
            static void Main(string[] args)
            {
                List<TakenBMI> data = new List<TakenBMI>() {
                   new TakenBMI() {TakenDate = DateTime.Parse("Aug-10-2014"), UerID = 34,  TakenItem = "Weight", TakenValue = 140},
                   new TakenBMI() {TakenDate = DateTime.Parse("Aug-10-2014"), UerID = 34,  TakenItem = "Height", TakenValue = 5.5},
                   new TakenBMI() {TakenDate = DateTime.Parse("Aug-15-2014"), UerID = 34,  TakenItem = "Weight", TakenValue = 141},
                   new TakenBMI() {TakenDate = DateTime.Parse("Aug-15-2014"), UerID = 34,  TakenItem = "Height", TakenValue = 5.5},
                };
                Dictionary<DateTime, List<TakenBMI>> dict = data.AsEnumerable()
                    .GroupBy(x => x.TakenDate, y => y)
                    .ToDictionary(x => x.Key, y => y.ToList());
            }
        }
        public class TakenBMI
        {
            public DateTime TakenDate {get;set;}
            public int UerID {get;set;}
            public string TakenItem {get;set;}
            public double TakenValue {get;set;} 
        }
    }
