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
            const string FILENAME1 = @"c:\temp\test1.xml";
            const string FILENAME2 = @"c:\temp\test2.xml";
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
                dt.Columns.Add("streets", typeof(string));
                dt.Rows.Add(new object[] { "USA", "Corperation", "LARGE", "WORKING", "newyork", 676306, 24.4251, 25.6011, 0.0, 87, "NEM", "", "", "firststreet" });
                dt.Rows.Add(new object[] { "USA", "Corperation", "LARGE", "WORKING", "newyork", 676306, 24.4251, 25.6011, 0.0, 87, "NEM", "", "", "downtownstreet" });
                dt.Rows.Add(new object[] { "USA", "Corperation", "LARGE", "WORKING", "chicago", 676306, 24.4251, 25.6011, 0.0, 87, "NEM", "", "", "chicstreet" });
                dt.Rows.Add(new object[] { "USA", "Corperation", "LARGE", "WORKING", "la", 676306, 24.4251, 25.6011, 0.0, 87, "NEM", "", "", "lastreet" });
                dt.Rows.Add(new object[] { "USA", "Corperation", "MEDIUM", "WORKING", "buffalo", 676306, 24.4251, 25.6011, 0.0, 87, "NEM", "", "", "buffalostreet" });
                dt.Rows.Add(new object[] { "USA", "Corperation", "MEDIUM", "WORKING", "buffalo", 676306, 24.4251, 25.6011, 0.0, 87, "NEM", "", "", "cowstreet" });
                dt.Rows.Add(new object[] { "USA", "Corperation", "MEDIUM", "WORKING", "denver", 676306, 24.4251, 25.6011, 0.0, 87, "NEM", "", "", "street" });
                dt.Rows.Add(new object[] { "USA", "Corperation", "MEDIUM", "NOT WORKING", "lasvegas", 676306, 24.4251, 25.6011, 0.0, 87, "NEM", "", "", "street" });
                dt.Rows.Add(new object[] { "USA", "Corperation", "SMALL", "WORKING", "trenton", 676306, 24.4251, 25.6011, 0.0, 87, "NEM", "", "", "street" });
                dt.Rows.Add(new object[] { "USA", "Village", "SMALL", "WORKING", "albany", 676306, 24.4251, 25.6011, 0.0, 87, "NEM", "", "", "street" });
                dt.Rows.Add(new object[] { "USA", "Village", "SMALL", "WORKING", "hartford", 676306, 24.4251, 25.6011, 0.0, 87, "NEM", "", "", "street" });
                dt.Rows.Add(new object[] { "SPAIN", "Corperation", "MEDIUM", "WORKING", "BARCELONA", 11111, 34.4251, 25.6011, 0.0, 82, "LEV" });
                dt.Rows.Add(new object[] { "ITALY", "Corperation", "LARGE", "WORKING", "ITALY", 21111, 14.4251, 15.6011, 0.0, 80, "MIR" });
                XDocument doc1 = XDocument.Load(FILENAME1);
                XElement kml = (XElement)doc1.FirstNode;
                XNamespace ns = kml.Name.Namespace;
                XElement document = doc1.Descendants().Where(x => x.Name.LocalName == "Document").FirstOrDefault();
                string documentStr = document.ToString();
                kml.RemoveAll();
                XDocument doc2 = XDocument.Load(FILENAME2);
                XElement linesDoc = (XElement)doc2.FirstNode;
                string linesStr = linesDoc.ToString();
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
                                var cityRows = cityTypeRow.GroupBy(x => x.Field<string>("cityname"));
                                foreach (var city in cityRows)
                                {
                                    string newDocumentStr = documentStr;
                                    newDocumentStr = newDocumentStr.Replace("***CITY NAME***", city.Key);
                                    newDocumentStr = newDocumentStr.Replace("***PIN***", city.FirstOrDefault().Field<int>("pin").ToString());
                                    newDocumentStr = newDocumentStr.Replace("***LONGITUDE***", city.FirstOrDefault().Field<double>("LONGITUDE").ToString());
                                    newDocumentStr = newDocumentStr.Replace("***LATITUDE***", city.FirstOrDefault().Field<double>("LATITUDE").ToString());
                                    newDocumentStr = newDocumentStr.Replace("***SCALE***", city.FirstOrDefault().Field<double>("SCALE").ToString());
                                    newDocumentStr = newDocumentStr.Replace("***TOTAL***", city.FirstOrDefault().Field<int>("TOTAL").ToString());
                                    newDocumentStr = newDocumentStr.Replace("***TILT***", city.FirstOrDefault().Field<string>("TILT"));
                                    newDocumentStr = newDocumentStr.Replace("***CH***", city.FirstOrDefault().Field<string>("CH"));
                                    newDocumentStr = newDocumentStr.Replace("***REGION***", city.FirstOrDefault().Field<string>("REGION"));
                                    XElement newCity = XElement.Parse(newDocumentStr);
                                    newCitySize.Add(newCity);
                                    foreach (var street in city)
                                    {
                                        if (street.Field<object>("streets") != null)
                                        {
                                            string newlinesStr = linesStr;
                                            newlinesStr = newlinesStr.Replace("***LONGITUDE***", street.Field<double>("LONGITUDE").ToString());
                                            newlinesStr = newlinesStr.Replace("***LATITUDE***", street.Field<double>("LATITUDE").ToString());
                                            newlinesStr = newlinesStr.Replace("***SCALE***", street.Field<double>("SCALE").ToString());
                                            newlinesStr = newlinesStr.Replace("***Site Id***", street.Field<string>("streets").ToString());
                                            XElement newLine = XElement.Parse(newlinesStr);
                                            newCity.Add(newLine.Elements());
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
