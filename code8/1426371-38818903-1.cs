    class Program
    {
        public delegate bool ProcuctComparator(Product elem,string Uservalue);
        static void Main(string[] args)
        {
            UsingXml op = new UsingXml();
            string Uservalue = "Product 1";
            ProcuctComparator delg = new ProcuctComparator(byProductName);
            op.parseXml(@"c:\temp\data.xml");
            var elem = op.myProducts.Products.AsParallel().Where(f =>
              {
                  return delg(f, Uservalue);
              }).Count();
            Console.WriteLine(elem);
            Console.ReadKey();
        }
        private static bool byProductName(Product elem, string Uservalue)
        {
            return elem.Product_name.Equals(Uservalue);
        }               
        
    }
     public class UsingXml
    {
        public ProductList myProducts { get; set; }
        public void parseXml(string filePath)
        {
            try
            {
                FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                XmlSerializer xmlSer = new XmlSerializer(typeof(ProductList));
                myProducts = (ProductList)xmlSer.Deserialize(fs);
            }
            catch(Exception ex)
            {
               
                    Console.WriteLine(ex.Message);
                
            }
        }
    }
     [XmlRoot("Table")]
    public class ProductList
    {
        public ProductList() { }
        [XmlElement(ElementName = "Product")]
        public List<Product> Products { get; set; }
    }
    public class Product
    {
        public Product() { }
        [XmlElement(ElementName = "Product_id")]
        public int Product_id { get; set; }
        [XmlElement(ElementName = "Product_name")]
        public string Product_name { get; set; }
        [XmlElement(ElementName = "Product_price")]
        public int Product_price { get; set; }       
    }
