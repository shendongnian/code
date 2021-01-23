    namespace Gfs
    {
    internal class Program
    {
        private static void Main(string[] args)
        {
            var gfList = new List<Girlfriend>();
            gfList.Add(new Girlfriend("Vicky", "Blonde", "Blue"));
            gfList.Add(new Girlfriend("Liz", "Blonde", "Blue"));
            gfList.Add(new Girlfriend("Sharon", "Blonde", "Blue"));
            var sean = new Sean(24, "Sean");
            foreach (var gf in gfList)
            {
                if (sean.CheckMatch(gf))
                {
                    Console.WriteLine("She is a match");
                }
                else
                {
                    Console.WriteLine("She is not a match");
                }
            }
        }
    }
    public class Girlfriend
    {
        public string name { get; set; }
        public int age { get; set; }
        public string hairColor { get; set; }
        public string eyeColor { get; set; }
        public static Random rnd = new Random();
        public Girlfriend(string name, string hairColor, string eyeColor)
        {
            this.name = name;
            this.hairColor = hairColor;
            this.eyeColor = eyeColor;
            this.age = rnd.Next(20, 30);
        }
    }
    public class Sean
    {
        private string name;
        private int age;
        public Sean(int age, string name)
        {
            name = this.name;
            age = this.age;
        }
        public bool CheckMatch(Girlfriend gf)
        {
            return age <= (gf.age + 5) && age >= (gf.age - 1);
        }
    }
    }
