    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication34
    {
        class Program
        {
            static void Main(string[] args)
            {
                string input = 
                     "<School>" +
                        "<Classes>" +
                            "<Class>" +
                                "<Id>1</Id>" +
                                "<Subject>Biology</Subject>" +
                                "<Teacher><Id>1</Id></Teacher>" +
                            "</Class>" +
                            "<Class>" +
                                "<Id>2</Id>" +
                                "<Subject>Advanced Biology</Subject>" +
                                "<Teacher><Id>1</Id></Teacher>" +
                            "</Class>" +        
                            "<Class>" +
                                "<Id>3</Id>" +
                                "<Subject>Algebra</Subject>" +
                                "<Teacher><Id>2</Id></Teacher>" +
                            "</Class>" +
                            "<Class>" +
                                "<Id>4</Id>" +
                                "<Subject>Trigonometry</Subject>" +
                                "<Teacher><Id>2</Id></Teacher>" +
                            "</Class>" +
                        "</Classes>" +
                        "<Teachers>" +
                            "<Teacher>" +
                                "<Id>1</Id>" +
                                "<Name>Biology Teacher</Name>" +
                                "<Classes>" +
                                    "<Class><Id>1</Id></Class>" +
                                    "<Class><Id>2</Id></Class>" +
                                "</Classes>" +
                            "</Teacher>" +
                            "<Teacher>" +
                                "<Id>2</Id>" +
                                "<Name>Biology Teacher</Name>" +
                                "<Classes>" +
                                    "<Class><Id>3</Id></Class>" +
                                    "<Class><Id>4</Id></Class>" +
                                "</Classes>" +
                            "</Teacher>" +
                        "</Teachers>" +
                    "</School>";
                XDocument doc = XDocument.Parse(input);
                var results = doc.Elements().Select(x => new {
                    classes = x.Element("Classes").Elements("Class").Select(y => new {
                        id = y.Element("Id").Value,
                        subject = y.Element("Subject").Value,
                        teacherId = y.Element("Teacher").Element("Id").Value 
                    }).ToList(),
                    teachers = x.Element("Teachers").Elements("Teacher").Select(y => new {
                        id = y.Element("Id").Value,
                        name = y.Element("Name").Value,
                        classIds = y.Element("Classes").Elements("Class").Select(z => z.Element("Id").Value).ToList()
                    }).ToList()
                }).FirstOrDefault();
            }
        }
    }
