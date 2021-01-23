    class Program
    {
        static void Main(string[] args)
        {
            var list = new Driven("Ragnarok");
            list.Items.Add(1);
            list.Items.Add(2);
            string json = JsonConvert.SerializeObject(list);
            Console.WriteLine(json);
            Console.ReadKey();
        }
    }
    public class Driven
    {
        public Driven(string name)
        {
            this.Name = name;
        }
        public List<int> Items { get; set; } = new List<int>();
        public string Name { get; set; }
    }
