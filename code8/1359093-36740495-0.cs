    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication85
    {
        class Program
        {
            static void Main(string[] args)
            {
                var inputs = new[]  {
                    new { name = "Tom", age = 30},
                    new { name = "John", age = 35}
                               };
                XElement nodeList = new XElement("NodeList");
                XElement node = new XElement("Node");
                nodeList.Add(node);
                foreach (var input in inputs)
                {
                    node.Add(new XElement("DataNode", new XAttribute[] { new XAttribute("Key", input.name), new XAttribute("Value", input.age)}));
                }
            }
        }
     
    }
