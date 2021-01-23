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
                string input =
                    "<rows>" +
                        "<row>" +
                            "<cell>a</cell>" +
                            "<cell>b</cell>" +
                            "<cell>c</cell>" +
                            "<cell>d</cell>" +
                            "<cell>e</cell>" +
                            "<cell>f</cell></row>" +
                        "<row>" +
                            "<cell>aa</cell>" +
                            "<cell>bb</cell>" +
                            "<cell>cc</cell>" +
                            "<cell>dd</cell>" +
                            "<cell>ee</cell>" +
                            "<cell>ff</cell>" +
                        "</row>" +
                    "</rows>";
                XElement rows = XElement.Parse(input);
                var results = rows.Descendants("row").Select(x => new
                {
                    cells = x.Elements("cell").Select(y => y.Value).ToList()
                }).ToList();
                List<string> thirdCells =  results.Select(x => x.cells[2]).ToList();
            }
        }
    }
    ​
