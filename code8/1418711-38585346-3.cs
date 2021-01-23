            public string Id { get; set; }
            public string Name { get; set; }
        }
        static void Main(string[] args)
        {
            IList<Product> ProductList = new List<Product>();
            string json = "{\"Id\": 1, \"Name\": \"tv\"},{\"Id\": 2, \"Name\": \"car\"}";
            string[] jsonArray = json.Split(new string[] { "},{" }, StringSplitOptions.None);
            foreach (string j in jsonArray)
            {
                string jsonTemp = j.Replace("{", "").Replace("}", "");
                string myJson = "{" + jsonTemp + "}";
                ProductList.Add(JsonConvert.DeserializeObject<Product>(myJson));
            }
        }
    }
