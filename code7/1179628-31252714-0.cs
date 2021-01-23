    class Program
    {
        class table
        {
            public string c1 { get; set; }
            public string c2 { get; set; }
        }
        class node
        {
            public string root { get; set; }
            public List<string> leafs { get; set; }
        }
        static void Main(string[] args)
        {
            List<table> list = new List<table>()
            {
                new table(){ c1="root1", c2="val1"},
                new table(){ c1="root1", c2="val2"},
                new table(){ c1="root1", c2="val3"},
                new table(){ c1="root2", c2="val1"},
                new table(){ c1="root2", c2="val2"},
            };
            var tree = (from l in list
                       group l by l.c1 into t
                       select new node { 
                           root = t.Key, 
                           leafs = t.Select(e => e.c2).ToList() 
                       }).ToList();
            foreach(node n in tree)
            {
                Console.WriteLine(n.root);
                foreach(string l in n.leafs)
                {
                    Console.WriteLine("\t{0}", l);
                }
            }
            Console.ReadLine();
        }
    }
