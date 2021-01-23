    public class Material
    {
        public Material(string name, int quantity)
        {
            this.Name=name;
            this.Quantity=quantity;
        }
        public string Name { get; private set; }
        public int Quantity { get; private set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Material> list=new List<Material>();
            list.Add(new Material("AAA", 10));
            list.Add(new Material("BBB", 20));
            list.Add(new Material("CCC", 5));
            list.Add(new Material("AAA", 5));
            list.Add(new Material("CCC", 20));
            Console.WriteLine("{0,6} {1,6}", "Mat", "Qty");
            foreach(var item in list.GroupBy((mat) => mat.Name))
            {
                Console.WriteLine("{0,6} {1,6}", item.Key, item.Sum((mat) => mat.Quantity));
            }
            //   Mat    Qty
            //   AAA     15
            //   BBB     20
            //   CCC     25
        }
    }
