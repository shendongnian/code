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
                    "<nd>" +
                        "<ni>" +
                            "<nv>" +
                                "<noid>Managed=1,Network=1,smtp=1</noid>" +
                                "<r>27</r>" +
                                "<r>4</r>" +
                            "</nv>" +
                            "<nv>" +
                                "<noid>Managed=1,Network=1,Ibc=1</noid>" +
                                "<r>8</r>" +
                                "<r>2</r>" +
                            "</nv>" +
                            "<nv>" +
                                "<noid>Server=1,Function=1,Location=24</noid>" +
                                "<r>124</r>" +
                                "<r>2</r>" +
                                "<r>43</r>" +
                                "<r>90</r>" +
                            "</nv>" +
                            "<nv>" +
                                "<noid>Unmanaged=9,Label=7,Place=5</noid>" +
                                "<r>10</r>" +
                                "<r>20</r>" +
                            "</nv>" +
                        "</ni>" +
                    "</nd>";
                XElement nd = XElement.Parse(input);
                var results = nd.Descendants("nv").Select(x => new
                {
                    noid = (string)x.Element("noid"),
                    r = x.Elements("r").Select(y => (int)y).ToList()
                }).ToList();
            }
        }
    }
    ​
