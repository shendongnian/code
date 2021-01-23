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
                dt.Rows.Add(new object[] { "SPAIN", "Corperation", "MEDIUM", "WORKING", "BARCELONA", 11111, 34.4251, 25.6011, 0.0, 82, "LEV" });
                dt.Rows.Add(new object[] { "ITALY", "Corperation", "LARGE", "WORKING", "ITALY", 21111, 14.4251, 15.6011, 0.0, 80, "MIR" });
                XDocument doc = XDocument.Load(FILENAME);
                XElement folder = doc.Descendants().Where(x => x.Name.LocalName == "Folder").FirstOrDefault();
                XNamespace ns = folder.Name.Namespace;
                string folderStr = folder.ToString();
                int count = 0;
                foreach (DataRow row in dt.AsEnumerable())
                {
                    string newFolderStr = folderStr;
                    newFolderStr = newFolderStr.Replace("***COUNTRY***", row.Field<string>("countryname"));
                    newFolderStr = newFolderStr.Replace("***CITY TYPE***", row.Field<string>("citytype"));
                    newFolderStr = newFolderStr.Replace("***SIZE***", row.Field<string>("size"));
                    newFolderStr = newFolderStr.Replace("***STATUS***", row.Field<string>("status"));
                    newFolderStr = newFolderStr.Replace("***CITY NAME***", row.Field<string>("cityname"));
                    newFolderStr = newFolderStr.Replace("***PIN***", row.Field<int>("pin").ToString());
                    newFolderStr = newFolderStr.Replace("***LONGITUDE***", row.Field<double>("LONGITUDE").ToString());
                    newFolderStr = newFolderStr.Replace("***LATITUDE***", row.Field<double>("LATITUDE").ToString());
                    newFolderStr = newFolderStr.Replace("***SCALE***", row.Field<double>("SCALE").ToString());
                    newFolderStr = newFolderStr.Replace("***TOTAL***", row.Field<int>("TOTAL").ToString());
                    newFolderStr = newFolderStr.Replace("***TILT***", row.Field<string>("TILT"));
                    newFolderStr = newFolderStr.Replace("***CH***", row.Field<string>("CH"));
                    newFolderStr = newFolderStr.Replace("***REGION***", row.Field<string>("REGION"));
                    XElement newFolder = XElement.Parse(newFolderStr);
                    if (++count == 1)
                    {
                        folder.ReplaceWith(newFolder);
                    }
                    else
                    {
                        folder = doc.Descendants().Where(x => x.Name.LocalName == "Folder").FirstOrDefault();
                        folder.AddAfterSelf(newFolder);
                    }
                }
            }
        }
    }
