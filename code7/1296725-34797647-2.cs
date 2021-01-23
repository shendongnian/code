    public class Thing
    {
        // Constructor sets all the values
        public Thing(string name, double theone, double dmg)
        {
            this.Name=name;
            this.TheOne=theone;
            this.Dmg=dmg;
        }
        public string Name { get; private set; }
        public double TheOne { get; private set; }
        public double Dmg { get; private set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Thing> list=new List<Thing>();
            list.Add(new Thing("wq", 1.1, 120));
            list.Add(new Thing("r", 0.2, 60));
            list.Add(new Thing("e", 0.8, 50));
            list.Add(new Thing("ba", 1.2, 40));
            list.Add(new Thing("extra", 0.8, 500));
            list.Sort((t1, t2) => t1.TheOne.CompareTo(t2.TheOne));
            double[] dmg_list=list.Select((t) => t.Dmg).ToArray();
        }
    }
