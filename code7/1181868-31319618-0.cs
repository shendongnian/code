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
                    "<authors>" +
                      "<author name=\"John\">" +
                        "<books>" +
                           "<book type=\"Children\">ABC</book>" +
                        "</books>" +
                      "</author>" +
                      "<author name=\"May\">" +
                        "<books>" +
                           "<book type=\"Children\">A beautiful day</book>" +
                        "</books>" +
                      "</author>" +
                      "<author name=\"John\">" +
                        "<books>" +
                           "<book type=\"Fiction\">BBC</book>" +
                        "</books>" +
                      "</author>" +
                    "</authors>";
                XElement element = XElement.Parse(input);
                var authors = element.Descendants("author").GroupBy(x => x.Attribute("name").Value).ToList();
                foreach (var author in authors)
                {
                    var books = author.Descendants("books");
                    for (int i = author.Count() - 1; i >= 1 ; i--)
                    {
                        var book = author.Skip(i).FirstOrDefault().Descendants("book");
                        books.Elements("book").First().Add(book);
                        author.Skip(i).DescendantNodesAndSelf().Remove();
                    }
                }
            }
            
        }
    }
