    class Person
    {
        public int Id { get; set; }        
    }
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            List<int> ints = new List<int>();
            List<Person> People = new List<Person>(1000);
            for (int i = 0; i < 7500; i++)
            {
                ints.Add(i);
                ints.Add(15000 - i - 1);
            }
            for (int i = 0; i < 45000; i++)
                People.Add(new Person() { Id = i });
            Stopwatch s = new Stopwatch();
            s.Start();
            // code A (uncomment it)         
            //Dictionary<int, int> dict = ints.ToDictionary(p => p);
            //List<Person> newList = People.Where(p => !dict.ContainsKey(p.Id)).ToList();
            // code B
            List<Person> newList = People.Where(p => !ints.Contains(p.Id)).ToList();
            s.Stop();
            Console.WriteLine(s.ElapsedMilliseconds);
            Console.WriteLine("Number of elements " + newList.Count);
            Console.ReadKey();
        }
