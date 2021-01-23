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
                foreach (XElement item in fileone.Descendants("Book"))
                {
                    string bookId = item.Attribute("BookID").Value;
                    List<XElement> bookTwoItems = secondxdoc.Descendants("Edition").Where(x => x.Attribute("BID").Value == bookId).ToList();
                    if (bookTwoItems.Count  == 0)
                    {
                        XElement newItem = new XElement("item");
                        output.Add(newItem);
                        newItem.Add(item);
                    }
                    else
                    {
                        foreach (XElement bookTwoItem in bookTwoItems)
                        {
                            XElement newItem = new XElement("item");
                            output.Add(newItem);
                            newItem.Add(item);
                            newItem.Add(bookTwoItem);
                        }
                    }
                    
                }
            
            }
        }
    }
    ​
