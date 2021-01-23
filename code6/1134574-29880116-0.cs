    class Datum
    {
        public string Composer { get; set; }
        ///wharever other proerties you need
        public string DisplayOutput()
        {
            return this.Composer //+ however you want it displayed
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Datum> data = new List<Datum>();
            foreach (var outputLine in data.Where(d => d.Composer == "Mozart").Select(d=>d.DisplayOutput())
            {
                Console.WriteLine(outputLine);
            }
            
        }
    }
