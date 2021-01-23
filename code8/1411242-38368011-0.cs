    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Product p = new Product();
                var x = p.ToXml();
                Console.WriteLine(x.ToString());
                Console.ReadLine();
            }
        }
        public abstract class XmlSerializable
        {
            public XElement ToXml() {
                XElement elm = new XElement(this.GetType().Name);
                this.GetType().GetProperties().ToList().ForEach(p => elm.Add(new XElement(p.Name, p.GetValue(this))));
                return elm;
            }
        }
        public class Product :XmlSerializable
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Desc { get; set; }
            public float Price { get; set; }
        }
    }
