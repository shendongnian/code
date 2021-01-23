    public class Data
    {
        public List<DataItem> Items { get; set; }
        private Data(XElement root)
        {
            Items = new List<DataItem>();
            foreach (XElement el in root.Elements())
            {
                Items.Add(new DataItem(el));
            }
        }
        public static Data Load(Stream stream)
        {
            return new Data(XDocument.Load(stream).Root);
        }
    }
    public class DataItem
    {
        public Dictionary<string, string> Vals;
        public string Id { get { return (string)Vals["Id"]; } }
        public DataItem(XElement el)
            {
                Vals = new Dictionary<string, string>();
                // Load all the element attributes into the Attributes Dictionary
                foreach (XAttribute att in el.Attributes())
                {
                    string name = att.Name.ToString();
                    string val = att.Value;
                    Vals.Add(name, val);
                }
            }
    }
