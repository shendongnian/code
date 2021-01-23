    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Data;
    namespace TestContacts
    {
        class Contact
        {
            public string Name = "";
        }
        class Program
        {
            static void Main(string[] args)
            {
                Contact c1 = new Contact();
                c1.Name = "Name1";
                Contact c2 = new Contact();
                c2.Name = "Name2";
                Contact c3 = new Contact();
                c3.Name = "Name3";
                //Simpliest approach could be saving it to data table 
                DataSet ds = new DataSet("Contact");
                DataTable dt = new DataTable("Info");
                dt.Columns.Add("name", typeof(string));
                //You can loop but for simplicity add one by one
                DataRow r1 = dt.NewRow();
                r1["name"] = c1.Name;
                dt.Rows.Add(r1);
                DataRow r2 = dt.NewRow();
                r2["name"] = c2.Name;
                dt.Rows.Add(r2);
                DataRow r3 = dt.NewRow();
                r3["name"] = c3.Name;
                dt.Rows.Add(r3);
                //Save to file using XML file format
                ds.Tables.Add(dt);
                ds.WriteXml("C:\\contacts.xml", XmlWriteMode.WriteSchema);
                //You can also load via
                ds.ReadXml("C:\\contacts.xml", XmlReadMode.ReadSchema);
            
            }
        }
    }
