    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.Data;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                DataTable dt = new DataTable();
                XmlReader reader = XmlReader.Create(FILENAME);
                Dictionary<string, string> colDict = new Dictionary<string, string>();
                while (!reader.EOF)
                {
                    if (reader.Name != "FIELD")
                    {
                        reader.ReadToFollowing("FIELD");
                    }
                    if (!reader.EOF)
                    {
                        XElement field = (XElement)XElement.ReadFrom(reader);
                        string attrname = (string)field.Attribute("attrname");
                        string fieldtype = (string)field.Attribute("fieldtype");
                        switch (fieldtype)
                        {
                            case "string" :
                                dt.Columns.Add(attrname, typeof(string));
                                break;
                            case "i4":
                                dt.Columns.Add(attrname, typeof(int));
                                break;
                        }
                        colDict.Add(attrname, fieldtype);
                    }
                }
                reader.Close();
                reader = XmlReader.Create(FILENAME);
                while (!reader.EOF)
                {
                    if (reader.Name != "ROW")
                    {
                        reader.ReadToFollowing("ROW");
                    }
                    if (!reader.EOF)
                    {
                        XElement row = (XElement)XElement.ReadFrom(reader);
                        DataRow newRow = dt.Rows.Add();
                        foreach (XAttribute attrib in row.Attributes())
                        {
                            string colName = attrib.Name.LocalName;
                            if (colDict.ContainsKey(colName))
                            {
                                switch (colDict[colName])
                                {
                                    case "string":
                                        newRow[colName] = (string)attrib;
                                        break;
                                    case "i4":
                                        newRow[colName] = (int)attrib;
                                        break;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
