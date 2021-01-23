    public class Program
    {
        public class Product
        {
            public string Id { get; set; }
            public string Name { get; set; }
        }
        static void Main(string[] args)
        {
            IList<Product> productList = new List<Product>();
            string json = "{\"Id\": 1, \"Name\": \"A\"},{\"Id\": 2, \"Name\": \"B\"}";
            string[] jsonArray = json.Split(new string[] { "},{" }, StringSplitOptions.None);
            foreach (string j in jsonArray)
            {
                string jsonTemp = j.Replace("{", "").Replace("}", "");
                string myJson = "{" + jsonTemp + "}";
                productList.Add(JsonConvert.DeserializeObject<Product>(myJson));
            }
        }
    }
