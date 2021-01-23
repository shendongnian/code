    public class Flying {
        public string FlyingFrom { get; private set; }
        public string FlyingTo { get; private set; }
        public Flying(string from, string to) {
            FlyingFrom = from;
            FlyingTo = to;
        }
    }
    using System.IO;
    
    static void Main(string[] args)
    {
        var reader = new StreamReader(File.OpenRead("test.csv"));
            List<Flying> flying = new List<Flying>();
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(';');
                flying.Add(new Flying(values[0], values[1]));
            }
            string userSelection = "fromA";
            Flying result = flying.Find(f => f.FlyingFrom.Equals(userSelection));
            Console.WriteLine(result.FlyingFrom + ": " + result.FlyingTo);
    }
