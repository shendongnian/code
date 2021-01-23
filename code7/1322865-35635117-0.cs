    public class Product
    {
        public string AsOfDate { get; set; }
        public double RateOfReturn { get; set; }
        public string FamAcctIndex { get; set; }
        public string RowID { get; set; }
        public string BrM { get; set; }
        public int ProductLineCode { get; set; }
    }
    public static IEnumerable<Product> ParseDataset(XDocument xd)
    {
        XNamespace ns = "http://developer.cognos.com/schemas/xmldata/1/";
        // parse out the column names
        Dictionary<string, int> headerPositions = xd.Root
            .Element(ns + "metadata")
            .Elements()
            .Select((name, idx) => new { pos = idx, name = (string)name.Attribute("name") })
            .ToDictionary(x => x.name, x => x.pos);
        foreach (XElement row in xd.Root.Descendants(ns + "row"))
        {
            List<string> vals = row.Elements().Select(x => x.Value).ToList();
            Product obj = new Product();
            foreach (PropertyInfo prop in typeof(Product).GetProperties())
            {
                string valToSet = vals[headerPositions[prop.Name]];
                prop.SetValue(obj, Convert.ChangeType(valToSet, prop.PropertyType);
            }
            yield return obj;
        }
    }
