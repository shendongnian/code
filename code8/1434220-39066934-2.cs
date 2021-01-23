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
                dt.Columns.Add("region", typeof(string));
                dt.Columns.Add("technology", typeof(string));
                dt.Columns.Add("sitetype", typeof(string));
                dt.Columns.Add("status", typeof(string));
                dt.Columns.Add("siteid", typeof(string));
                dt.Columns.Add("cellid", typeof(int));
                dt.Columns.Add("LONGITUDE", typeof(double));
                dt.Columns.Add("LATITUDE", typeof(double));
                dt.Columns.Add("SCALE", typeof(double));
                dt.Rows.Add(new object[] { "BNGLR", "G", "MACRO", "WORKING", "2330", 23301, 24.4251, 25.6011, 87});
                dt.Rows.Add(new object[] { "BNGLR", "G", "MACRO", "WORKING", "2330", 23302, 24.4251, 25.6011, 88});
                dt.Rows.Add(new object[] { "BNGLR", "G", "MACRO", "WORKING", "2330", 23303, 24.4251, 25.6011, 89 });
                dt.Rows.Add(new object[] { "BNGLR", "G", "MACRO", "OTHERS", "2330", 23304, 27.4251, 54.6011, 89 });
                dt.Rows.Add(new object[] { "BNGLR", "G", "MICRO", "WORKING", "2331", 23311, 25.4251, 25.6011, 90 });
                dt.Rows.Add(new object[] { "BNGLR", "G", "INDOOR", "WORKING", "2332", 23321, 26.4251, 25.6011, 87 });
                dt.Rows.Add(new object[] { "BNGLR", "U", "MACRO", "WORKING", "4330", 43301, 37.4251, 25.6011, 82 });
                dt.Rows.Add(new object[] { "BNGLR", "L", "MACRO", "WORKING", "5330", 53301, 19.4251, 15.6011, 80 });
                XDocument doc1 = XDocument.Load(FILENAME1);
                XElement kml = (XElement)doc1.FirstNode;
                XNamespace ns = kml.Name.Namespace;
                XElement document = doc1.Descendants().Where(x => x.Name.LocalName == "Document").FirstOrDefault();
                string documentStr = document.ToString();
                kml.RemoveAll();
                XDocument doc2 = XDocument.Load(FILENAME2);
                XElement linesDoc = (XElement)doc2.FirstNode;
                string linesStr = linesDoc.ToString();
                var regionRows = dt.AsEnumerable().GroupBy(x => x.Field<string>("region"));
                foreach (var region in regionRows)
                {
                    XElement newRegion = new XElement(ns + "Folder", new object[] {
                           new XElement(ns + "name", region.Key),
                           new XElement(ns + "open", 1)
                    });
                    kml.Add(newRegion);
                    var technologyRows = region.GroupBy(x => x.Field<string>("technology"));
                    foreach (var technologyRow in technologyRows)
                    {
                        XElement newTechnology = new XElement(ns + "Folder", new object[] {
                           new XElement(ns + "name", technologyRow.Key),
                           new XElement(ns + "open", 1)
                        });
                        newRegion.Add(newTechnology);
                        var sitetypeRows = technologyRow.GroupBy(x => x.Field<string>("sitetype"));
                        foreach (var siteTypeRow in sitetypeRows)
                        {
                            XElement newSiteType = new XElement(ns + "Folder", new object[] {
                               new XElement(ns + "name", siteTypeRow.Key)
                            });
                            newTechnology.Add(newSiteType);
                            var siteStatusRows = siteTypeRow.GroupBy(x => x.Field<string>("status"));
                            foreach (var siteStatusRow in siteStatusRows)
                            {
                                XElement newStatus = new XElement(ns + "Folder", new object[] {
                                   new XElement(ns + "name", siteStatusRow.Key)
                                });
                                newSiteType.Add(newStatus);
                            
                                foreach(var location in siteStatusRow)
                                {
                                    string newDocumentStr = documentStr;
                                    newDocumentStr = newDocumentStr.Replace("***Site Id***", location.Field<string>("siteid"));
                                    newDocumentStr = newDocumentStr.Replace("***CI***", location.Field<int>("cellid").ToString());
                                    newDocumentStr = newDocumentStr.Replace("***LONGITUDE***", location.Field<double>("LONGITUDE").ToString());
                                    newDocumentStr = newDocumentStr.Replace("***LATITUDE***", location.Field<double>("LATITUDE").ToString());
                                    newDocumentStr = newDocumentStr.Replace("***SCALE***", location.Field<double>("SCALE").ToString());
                                    XElement newDoc = XElement.Parse(newDocumentStr);
                                    newSiteType.Add(newDoc);
                                    string newlinesStr = linesStr;
                                    newlinesStr = newlinesStr.Replace("***LONGITUDE***", location.Field<double>("LONGITUDE").ToString());
                                    newlinesStr = newlinesStr.Replace("***LATITUDE***", location.Field<double>("LATITUDE").ToString());
                                    newlinesStr = newlinesStr.Replace("***SCALE***", location.Field<double>("SCALE").ToString());
                                    newlinesStr = newlinesStr.Replace("***SITE ID***", location.Field<string>("siteid"));
                                    XElement newLine = XElement.Parse(newlinesStr);
                                    newDoc.Add(newLine.Elements());
                                }
                            }
                        }
                    }
                }
            }
        }
    }
