    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication9
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("countryname", typeof(string));
                dt.Columns.Add("citytype", typeof(string));
                dt.Columns.Add("size", typeof(string));
                dt.Columns.Add("status", typeof(string));
                dt.Columns.Add("cityname", typeof(string));
                dt.Columns.Add("pin", typeof(int));
                dt.Columns.Add("LONGITUDE", typeof(double));
                dt.Columns.Add("LATITUDE", typeof(double));
                dt.Columns.Add("SCALE", typeof(double));
                dt.Columns.Add("TOTAL", typeof(int));
                dt.Columns.Add("TILT", typeof(string));
                dt.Columns.Add("CH", typeof(string));
                dt.Columns.Add("REGION", typeof(string));
                dt.Rows.Add(new object[] { "USA", "Corperation", "LARGE", "WORKING", "newyork", 676306, 24.4251, 25.6011, 0.0, 87, "NEM" });
                dt.Rows.Add(new object[] { "USA", "Corperation", "LARGE", "WORKING", "chicago", 676306, 24.4251, 25.6011, 0.0, 87, "NEM" });
                dt.Rows.Add(new object[] { "USA", "Corperation", "LARGE", "WORKING", "la", 676306, 24.4251, 25.6011, 0.0, 87, "NEM" });
                dt.Rows.Add(new object[] { "USA", "Corperation", "MEDIUM", "WORKING", "buffalo", 676306, 24.4251, 25.6011, 0.0, 87, "NEM" });
                dt.Rows.Add(new object[] { "USA", "Corperation", "MEDIUM", "WORKING", "denver", 676306, 24.4251, 25.6011, 0.0, 87, "NEM" });
                dt.Rows.Add(new object[] { "USA", "Corperation", "MEDIUM", "NOT WORKING", "lasvegas", 676306, 24.4251, 25.6011, 0.0, 87, "NEM" });
                dt.Rows.Add(new object[] { "USA", "Corperation", "SMALL", "WORKING", "trenton", 676306, 24.4251, 25.6011, 0.0, 87, "NEM" });
                dt.Rows.Add(new object[] { "USA", "Village", "SMALL", "WORKING", "albany", 676306, 24.4251, 25.6011, 0.0, 87, "NEM" });
                dt.Rows.Add(new object[] { "USA", "Village", "SMALL", "WORKING", "hartford", 676306, 24.4251, 25.6011, 0.0, 87, "NEM" });
                dt.Rows.Add(new object[] { "SPAIN", "Corperation", "MEDIUM", "WORKING", "BARCELONA", 11111, 34.4251, 25.6011, 0.0, 82, "LEV" });
                dt.Rows.Add(new object[] { "ITALY", "Corperation", "LARGE", "WORKING", "ITALY", 21111, 14.4251, 15.6011, 0.0, 80, "MIR" });
                XDocument doc = XDocument.Load(FILENAME);
                XElement kml = (XElement)doc.FirstNode;
                XNamespace ns = kml.Name.Namespace;
                XElement document = doc.Descendants().Where(x => x.Name.LocalName == "Document").FirstOrDefault();
                string documentStr = document.ToString();
                kml.RemoveAll();
                var countryRows = dt.AsEnumerable().GroupBy(x => x.Field<string>("countryname"));
                foreach (var country in countryRows)
                {
                    XElement newCountry = new XElement(ns + "Folder", new object[] {
                           new XElement(ns + "name", country.Key),
                           new XElement(ns + "open", 1)
                    });
                    kml.Add(newCountry);
                    var cityTypeRows = country.GroupBy(x => x.Field<string>("citytype"));
                    foreach (var cityTypeRow in cityTypeRows)
                    {
                        XElement newCityType = new XElement(ns + "Folder", new object[] {
                           new XElement(ns + "name", cityTypeRow.Key),
                           new XElement(ns + "open", 1)
                        });
                        newCountry.Add(newCityType);
                        var citySizeRows = cityTypeRow.GroupBy(x => x.Field<string>("size"));
                        foreach (var citySizeRow in citySizeRows)
                        {
                            XElement newCitySize = new XElement(ns + "Folder", new object[] {
                               new XElement(ns + "name", citySizeRow.Key)
                            });
                            newCityType.Add(newCitySize);
                            var cityStatusRows = cityTypeRow.GroupBy(x => x.Field<string>("status"));
                            foreach (var cityStatusRow in cityStatusRows)
                            {
                                XElement newStatus = new XElement(ns + "Folder", new object[] {
                                   new XElement(ns + "name", cityStatusRow.Key)
                                });
                                newCitySize.Add(newStatus);
                                foreach (DataRow city in cityStatusRow)
                                {
                                    string newDocumentStr = documentStr;
                                    newDocumentStr = newDocumentStr.Replace("***CITY NAME***", city.Field<string>("cityname"));
                                    newDocumentStr = newDocumentStr.Replace("***PIN***", city.Field<int>("pin").ToString());
                                    newDocumentStr = newDocumentStr.Replace("***LONGITUDE***", city.Field<double>("LONGITUDE").ToString());
                                    newDocumentStr = newDocumentStr.Replace("***LATITUDE***", city.Field<double>("LATITUDE").ToString());
                                    newDocumentStr = newDocumentStr.Replace("***SCALE***", city.Field<double>("SCALE").ToString());
                                    newDocumentStr = newDocumentStr.Replace("***TOTAL***", city.Field<int>("TOTAL").ToString());
                                    newDocumentStr = newDocumentStr.Replace("***TILT***", city.Field<string>("TILT"));
                                    newDocumentStr = newDocumentStr.Replace("***CH***", city.Field<string>("CH"));
                                    newDocumentStr = newDocumentStr.Replace("***REGION***", city.Field<string>("REGION"));
                                    XElement newCity = XElement.Parse(newDocumentStr);
                                    newCitySize.Add(newCity);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
