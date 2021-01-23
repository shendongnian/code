    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Serialization;
    
    public class Program
    {
        private static void Main(string[] args)
        {
            var address = new MyAddress();
    
            address.Rows = new List<Row>();
    
            var rows = new List<Row>();
            rows.Add(new Row { Home = "Home A" });
            rows.Add(new Row { Home = "Home B" });
            rows.Add(new Row { Home = "Home B" });
    
            var items = rows.Select((x, index) => new Row 
            {
                Home = x.Home,
                Office = x.Office,
                Index = ++index
            });
    
            address.Rows.AddRange(items);
    
            var xmlS = new XmlSerializer(typeof(MyAddress));
            xmlS.Serialize(Console.Out, address);
        }
    }
    
    public class MyAddress
    {
        public MyAddress()
        {
            Rows = new List<Row>();
        }
    
        public List<Row> Rows { get; set; }
    }
    
    public class Row
    {
        [XmlAttribute]
        public int Index { get; set; }
    
        public string Home { get; set; }
    
        public string Office { get; set; }
    }
