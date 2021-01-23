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
                string input1 =
                   "<fileone>" +
                       "<Book BookID=\"dog\"> Dog </Book>" +
                       "<Book BookID=\"cat\"> Cat </Book>" +
                   "</fileone>";
                XDocument fileone = XDocument.Parse(input1);
                string input2 =
                   "<filetwo>" +
                          "<Edition BID=\"cat\" OrderID=\"100\"> about cat</Edition>" +
                          "<Edition BID=\"cat\" OrderID=\"200\">more about cat</Edition>" +
                   "</filetwo>";
                XDocument secondxdoc = XDocument.Parse(input2);
                //<item>
                //   <Book BookID="cat"> Dog </Book>
                //</item>
                //<item>
                //    <Book BookID="cat"> Cat </Book>
                //    <Edition BID="cat" OrderID="100"> about cat</Edition>
                //</item>
                //<item>
                //    <Book BookID="cat"> Cat </Book>
                //    <Edition BID="cat" OrderID="200"> more cat</Edition>
                //</item>
                XElement output = new XElement("Root");
                var results = (from one in fileone.Descendants("Book")
                               join two in secondxdoc.Descendants("Edition") on one.Attribute("BookID").Value equals two.Attribute("BID").Value into inners
                               from two in inners.DefaultIfEmpty()
                               select new { fileone = one, filetwo = two == null ? null : two })
                               .Select(x => x.filetwo == null ? new XElement("item", x.fileone) : new XElement("item", new object[] { x.fileone, x.filetwo }));
                foreach (var item in results)
                {
                    output.Add(item);
                }
            }
        }
    }
    ​
