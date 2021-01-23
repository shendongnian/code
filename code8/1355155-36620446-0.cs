    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.Data;
    namespace ConsoleApplication85
    {
        class Program
        {
            static void Main(string[] args)
            {
                string xml =
                    "<candidatelist>" +
                      "<comment>" +
                        "created 15.03.2016" +
                      "</comment>" +
                      "<candidates>" +
                        "<candidate>" +
                          "<personalinfo>" +
                            "<name>Parker</name>" +
                            "<firstname>Peter</firstname>" +
                            "<sex>M</sex>" +
                            "<birthday>19.02.1993</birthday>" +
                            "<group>group1</group>" +
                            "<language>E</language>" +
                            "<type>H</type>" +
                          "</personalinfo>" +
                          "<items>" +
                            "<item>item1</item>" +
                            "<item>item2</item>" +
                            "<item>item3</item>" +
                            "<item>item4</item>" +
                            "<item>item5</item>" +
                            "<item>item6</item>" +
                            "<item>item7</item>" +
                            "<item>item8</item>" +
                          "</items>" +
                        "</candidate>" +
                        "<candidate>" +
                          "<personalinfo>" +
                            "<name>Parker</name>" +
                            "<firstname>Peter</firstname>" +
                            "<sex>M</sex>" +
                            "<birthday>19.02.1993</birthday>" +
                            "<group>group1</group>" +
                            "<language>E</language>" +
                            "<type>H</type>" +
                          "</personalinfo>" +
                          "<items>" +
                            "<item>item1</item>" +
                            "<item>item2</item>" +
                            "<item>item3</item>" +
                            "<item>item4</item>" +
                            "<item>item5</item>" +
                            "<item>item6</item>" +
                            "<item>item7</item>" +
                            "<item>item8</item>" +
                          "</items>" +
                        "</candidate>" +
                      "</candidates>" +
                    "</candidatelist>";
                XDocument doc = XDocument.Parse(xml);
                DataTable dt = new DataTable();
                dt.Columns.Add("name", typeof(string));
                dt.Columns.Add("firstname", typeof(string));
                dt.Columns.Add("sex", typeof(string));
                dt.Columns.Add("birthday", typeof(string));
                dt.Columns.Add("group", typeof(string));
                dt.Columns.Add("language", typeof(string));
                dt.Columns.Add("type", typeof(string));
                dt.Columns.Add("item1", typeof(string));
                dt.Columns.Add("item2", typeof(string));
                dt.Columns.Add("item3", typeof(string));
                dt.Columns.Add("item4", typeof(string));
                dt.Columns.Add("item5", typeof(string));
                dt.Columns.Add("item6", typeof(string));
                dt.Columns.Add("item7", typeof(string));
                dt.Columns.Add("item8", typeof(string));
                dt.Columns.Add("item9", typeof(string));
                dt.Columns.Add("item10", typeof(string));
                List<XElement> candidates = doc.Descendants("candidate").ToList();
                foreach (XElement candidate in candidates)
                {
                    DataRow newRow = dt.Rows.Add();
                    newRow["name"] = (string)candidate.Descendants("name").FirstOrDefault();
                    newRow["firstname"] = (string)candidate.Descendants("firstname").FirstOrDefault();
                    newRow["sex"] = (string)candidate.Descendants("sex").FirstOrDefault();
                    newRow["birthday"] = (string)candidate.Descendants("birthday").FirstOrDefault();
                    newRow["group"] = (string)candidate.Descendants("group").FirstOrDefault();
                    newRow["language"] = (string)candidate.Descendants("language").FirstOrDefault();
                    newRow["type"] = (string)candidate.Descendants("type").FirstOrDefault();
                    List<string> items = candidate.Descendants("item").Select(x => (string)x).ToList();
                    for (int index = 1; index <= items.Count; index++)
                    {
                        newRow["item" + index.ToString()] = items[index - 1];
                    }
                    
                }
            }
        }
    }
