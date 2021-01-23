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
                    "<Root>" +
                        "<ItemGroup>" +
                            "<Reference Include=\"Microsoft.CSharp\" />" +
                            "<Reference Include=\"System.Data.OracleClient\" />" +
                            "<Reference Include=\"System.Messaging\" />" +
                            "<Reference Include=\"System.Web.DynamicData\" />" +
                            "<Reference Include=\"System.Web.Entity\" />" +
                            "<Reference Include=\"System.Web.ApplicationServices\" />" +
                            "<Reference Include=\"System.ComponentModel.DataAnnotations\" />" +
                            "<Reference Include=\"System\" />" +
                            "<Reference Include=\"System.Data\" />" +
                            "<Reference Include=\"System.Core\" />" +
                            "<Reference Include=\"System.Data.DataSetExtensions\" />" +
                            "<Reference Include=\"System.Web.Extensions\" />" +
                            "<Reference Include=\"System.Xml.Linq\" />" +
                            "<Reference Include=\"System.Drawing\" />" +
                            "<Reference Include=\"System.Web\" />" +
                            "<Reference Include=\"System.Xml\" />" +
                            "<Reference Include=\"System.Configuration\" />" +
                            "<Reference Include=\"System.Web.Services\" />" +
                            "<Reference Include=\"System.EnterpriseServices\" />" +
                          "</ItemGroup>" +
                      "</Root>";
                XDocument doc = XDocument.Parse(input);
                List<XElement> itemGroup = doc.Descendants("ItemGroup").ToList();
                itemGroup.Elements("Reference").Where(x => x.Attribute("Include").Value == "System.Data").Remove();
            }
        }
    }
    ​
