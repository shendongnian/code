    public class Thing
    {
        public string Name { get; set; }
        public double TheOne { get; set; }
        public double Dmg { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Thing> list=new List<Thing>() {
                new Thing() { Name = "wq", TheOne = 1.1, Dmg=120 },
                new Thing() { Name = "r", TheOne = 0.2, Dmg=60 },
                new Thing() { Name = "e", TheOne = 0.8, Dmg=50 },
                new Thing() { Name = "ba", TheOne = 1.2, Dmg=40 },
                new Thing() { Name = "extra", TheOne = 0.8, Dmg=500 },
            };
            list.Sort((t1, t2) => t1.TheOne.CompareTo(t2.TheOne));
            double[] dmg_list=list.Select((t) => t.Dmg).ToArray();
            
        }
    }
