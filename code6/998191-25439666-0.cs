    public class Item
    {
        public string ID { get; set; }
        public List<FD> fd { get; set; }
    }
    public class FD
    {
        public string titie { get; set; }
        public string type { get; set; }
        public Views views { get; set; }
    }
    public class Views
    {
        public Graph graph { get; set; }
    }
    public class Graph
    {
        public bool show { get; set; }
        public State state { get; set; }
    }
    public class State
    {
        public string group { get; set; }
        public string[] series { get; set; }
        public string graphType { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string json = @"..."; //your json string
            var Items = JsonConvert.DeserializeObject<List<Item>>(json);
            List<string> tities = new List<string>();
            foreach (var Item in Items)
            {
                foreach (var fd in Item.fd)
                {
                    tities.Add(fd.titie);
                }
            }
        }
    }
