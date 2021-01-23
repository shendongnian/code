    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.Data;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Country", typeof(string));
                dt.Columns.Add("Name", typeof(string));
                dt.Columns.Add("address", typeof(string));
                dt.Columns.Add("id", typeof(string));
                dt.Rows.Add(new object[] { "India", "X1", "Y1", "Z1" });
                dt.Rows.Add(new object[] { "India", "X2", "Y2", "Z2" });
                dt.Rows.Add(new object[] { "India", "X3", "Y3", "Z3" });
                dt.Rows.Add(new object[] { "USA", "X4", "Y4", "Z4" });
                string identification =
                    "<?xml version=\"1.0\" encoding=\"utf-8\"?>" +
                    "<EmployeeList xmlns=\"http://tempuri.org/format.xsd\" key=\"lank\">" +
                    "</EmployeeList>";
                XDocument doc = XDocument.Parse(identification);
                XElement employeelist = doc.Root;
                //method 1 by grouping countries
                var results = dt.AsEnumerable()
                    .GroupBy(x => x.Field<string>("Country")).ToList();
                foreach (var rows in results)
                {
                    XElement newCountry = new XElement("Country", new XAttribute("id",string.Format("**{0}**", rows.FirstOrDefault().Field<string>("Country"))));
                    employeelist.Add(newCountry);
                    foreach (DataRow employee in rows)
                    {
                        newCountry.Add(new XElement("Emp", new XAttribute[] {
                            new XAttribute("Name", employee.Field<string>("Name")),
                            new XAttribute("address", employee.Field<string>("address")),
                            new XAttribute("id", employee.Field<string>("id"))
                        }));
                    }
                }
                //method 2 by adding
                doc = XDocument.Parse(identification);
                employeelist = doc.Root;
                foreach (var employee in dt.AsEnumerable())
                {
                    //test if country exists
                    string countryName = string.Format("**{0}**", employee.Field<string>("Country"));
                    XElement country = doc.Descendants("Country").Where(x => x.Attribute("id").Value == countryName).FirstOrDefault();
                    if (country == null)
                    {
                        country = new XElement("Country", new XAttribute("id", countryName));
                        employeelist.Add(country);
                    }
                    country.Add(new XElement("Emp", new XAttribute[] {
                        new XAttribute("Name", employee.Field<string>("Name")),
                        new XAttribute("address", employee.Field<string>("address")),
                        new XAttribute("id", employee.Field<string>("id"))
                    }));
                    
                }
            }
        }
    }
    ​
