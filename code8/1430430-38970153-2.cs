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
                string xml1Str =
                    "<root>" +
                    "<users>" +
                        "<ID>1</ID>" +
                        "<user_login>admin</user_login>" +
                        "<user_pass>$P$Bdfdffddkjlkiyuyadnvjd</user_pass>" +
                        "<term_id>2</term_id>" +
                        "<user_activation_key></user_activation_key>" +
                        "<user_status>0</user_status>" +
                        "<display_name>admin</display_name>" +
                    "</users>" +
                    "</root>";
                XElement xml1 = XElement.Parse(xml1Str);
                XElement xml1FirstNode = (XElement)xml1.FirstNode;
                string[] xml1ColNames = xml1FirstNode.Elements().Select(x => x.Name.LocalName).ToArray();
                string xml2Str =
                    "<root>" +
                    "<terms>" +
                        "<term_id>2</term_id>" +
                        "<name>name</name>" +
                        "<term_group>0</term_group>" +
                    "</terms>" +
                    "</root>";
                XElement xml2 = XElement.Parse(xml2Str);
                XElement xml2FirstNode = (XElement)xml2.FirstNode;
                string[] xml2ColNames = xml2FirstNode.Elements().Select(x => x.Name.LocalName).ToArray();
     
                DataTable dt = new DataTable();
                string[] colNames = xml1ColNames.Union(xml2ColNames).ToArray();
                foreach (var colName in colNames)
                {
                    dt.Columns.Add(colName, typeof(string));
                }
                try
                {
                    var groups = from x1 in xml1.Elements()
                                 join x2 in xml2.Elements()
                                 on (string)x1.Element("term_id") equals (string)x2.Element("term_id")
                                 select new { x1 = x1, x2 = x2 };
                    foreach (var group in groups)
                    {
                        DataRow newRow = dt.Rows.Add();
                        foreach (var x1Value in group.x1.Elements())
                        {
                            newRow[x1Value.Name.LocalName] = (string)x1Value;
                        }
                        foreach (var x2Value in group.x2.Elements())
                        {
                            newRow[x2Value.Name.LocalName] = (string)x2Value;
                        }
                    }
                    frm.dgv_ShowUsers.DataSource = dt;
                }
                catch (Exception e)
                {
                }
            }
        }
    }
