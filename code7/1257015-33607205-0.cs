    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    using System.Xml;
    namespace ConsoleApplication56
    {
        class Program
        {
            static void Main(string[] args)
            {
                string response = "";
                XmlReader reader = XmlReader.Create(response);
                DataSet ds = new DataSet();
                ds.ReadXml(reader);
            }
        }
    }
