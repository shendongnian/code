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
                string xml1 =
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
                XElement users = XElement.Parse(xml1);
                string xml2 =
                    "<root>" +
                    "<terms>" +
                        "<term_id>2</term_id>" +
                        "<name>name</name>" +
                        "<term_group>0</term_group>" +
                    "</terms>" +
                    "</root>";
                DataTable dt = new DataTable();
                dt.Columns.Add("ID", typeof(int));
                dt.Columns.Add("Login", typeof(string));
                dt.Columns.Add("Password", typeof(string));
                dt.Columns.Add("TermID", typeof(int));
                dt.Columns.Add("Key", typeof(string));
                dt.Columns.Add("Status", typeof(int));
                dt.Columns.Add("DisplayName", typeof(string));
                dt.Columns.Add("Name", typeof(string));
                dt.Columns.Add("Group", typeof(int));
                XElement terms = XElement.Parse(xml2);
                try
                {
                    var groups = from user in users.Elements("users") 
                                join term in terms.Elements("terms")
                                on (int)user.Element("term_id") equals (int)term.Element("term_id")
                                select new { user = user, term = term };
                    foreach (var group in groups)
                    {
                        
                        dt.Rows.Add(new object[] {
                           (int)group.user.Element("ID"),
                           (string)group.user.Element("user_login"),
                           (string)group.user.Element("user_pass"),
                           (int)group.user.Element("term_id"),
                           (string)group.user.Element("user_activation_key"),
                           (int)group.user.Element("user_status"),
                           (string)group.user.Element("display_name"),
                           (string)group.term.Element("Name"),
                           (int)group.term.Element("term_group")
                        });
                    }
                    frm.dgv_ShowUsers.DataSource = dt;
                }
                catch (Exception e)
                {
                }
            }
        }
    }
