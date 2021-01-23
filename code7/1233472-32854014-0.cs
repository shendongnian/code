    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.Text.RegularExpressions;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string input =
                    "<ni>" +
                        "<nss>20150927</nss>" +
                        "<gp>Addon</gp>" +
                        "<ns>CounterBlah1</ns>" +
                        "<ns>CounterBlah2</ns>" +
                        "<ns>CounterSales</ns>" +
                        "<ns>CounterBlah4</ns>" +
                        "<ns>CounterBlah5</ns>" +
                        "<ns>CounterBlah6</ns>" +
                        "<nv>" +
                            "<nad>Style=1,Rfu=1,Id=132</nad>" +
                            "<r>0</r>" +
                            "<r>15</r>" +
                            "<r>8</r>" +
                            "<r>3</r>" +
                            "<r>2</r>" +
                            "<r>2</r>" +
                        "</nv>" +
                        "<nv>" +
                            "<nad>Style=1,Rfu=1,Id=433</nad>" +
                            "<r>0</r>" +
                            "<r>15</r>" +
                            "<r>30</r>" +
                            "<r>3</r>" +
                            "<r>2</r>" +
                            "<r>2</r>" +
                        "</nv>" +
                        "<nv>" +
                            "<nad>Style=1,Rfu=1,Id=665</nad>" +
                            "<r>0</r>" +
                            "<r>15</r>" +
                            "<r>90</r>" +
                            "<r>3</r>" +
                            "<r>2</r>" +
                            "<r>2</r>" +
                        "</nv>" +
                    "</ni>";
                XElement ni = XElement.Parse(input);
                var results1 = ni.Descendants("nv").Select(x => new
                {
                    nad = x.Element("nad").Value,
                    r = x.Elements("r").Select(y => y.Value).ToList()
                }).ToList();
                var results2 = results1.Select(x => new {
                    Id = Helper(x.nad, "Id"),
                    r = int.Parse(x.r[2])
                }).ToList();
            }
            static int? Helper(string csv, string name)
            {
                int? results = null;
                string pattern = @"(?'name'\w+)=(?'value'\d+)";
                MatchCollection matches = Regex.Matches(csv, pattern);
                foreach(Match match in matches)
                {
                    string csvName = match.Groups["name"].Value;
                    if(csvName == name)
                    {
                        results = int.Parse(match.Groups["value"].Value);
                        break;
                    }
                }
                return results;
            }
        }
    }
    ​
