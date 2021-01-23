    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string xml =
                    "<table border=\"1\">" +
                    "<tr>" +
                    "<td><b>Name</b></td>" +
                    "<td><b>Selection</b></td>" +
                    "</tr>" +
                    "<tr>" +
                    "<td>Color</td>" +
                    "<td>1,2,3</td>" +
                    "</tr>" +
                    "<tr>" +
                    "<td>Shape</td>" +
                    "<td>a,b</td>" +
                    "</tr>" +
                    "<tr>" +
                    "<td>Cut</td>" +
                    "<td>x</td>" +
                    "</tr>" +
                    "<tr>" +
                    "<td>Range</td>" +
                    "<td>y</td>" +
                    "</tr>" +
                    "<tr>" +
                    "<td>Purity</td>" +
                    "<td>8,9</td>" +
                    "</tr>" +
                    "</table>";
                XElement table = XElement.Parse(xml);
                List<Data> data = table.Descendants("tr").Select(x => new Data() {
                    name = x.Elements().Take(1).FirstOrDefault().Value,
                    values = x.Elements().Skip(1).FirstOrDefault().Value.Split(new char[] {','}).ToList()
                }).Skip(1).ToList();
                Recursion recursion = new Recursion(data);
                List<string> results = recursion.GetData(0);
            }
        }
        public class Data
        {
            public string name { get; set; }
            public List<string> values { get; set; }
        }
        public class Recursion
        {
            public List<Data> data { get; set; }
            public Recursion(List<Data> data)
            {
                this.data = data;
            }
            public List<string> GetData(int level)
            {
                if (level == data.Count - 1)
                {
                    return data[level].values;
                }
                else
                {
                    List<string> children = GetData(level + 1);
                    List<string> results = data[level].values.Select(x => children.Select(y => x + y)).SelectMany(z => z).ToList();
                    return results;
                }
                
            }
        }
    }
    ​
