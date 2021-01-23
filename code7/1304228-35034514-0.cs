    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication70
    {
        class Program
        {
            static void Main(string[] args)
            {
                string xml =
                "<connectionStrings>" +
                    "<add name=\"SqlServer\"" +
                             " connectionString=\"Data Source=192.168.1.1; Initial Catalog=s; Application Name=s; MultipleActiveResultSets = true; Pooling=True; User ID=1111;Password=1111;\" />" +
                    "<add name=\"SqlServer_WinAuthentication\"" +
                             " connectionString=\"Data Source=.; Initial Catalog=MeterShop; Integrated Security=True; Application Name=MeterShop; MultipleActiveResultSets = true; Pooling=True;\" />" +
                    "<add name=\"SqlServer_SqlAuthentication\"" +
                             " connectionString=\"Data Source=.; Initial Catalog=MeterShop; User ID=1; Password=1; Application Name=1; MultipleActiveResultSets = true; Pooling=True;\" />" +
                "</connectionStrings>";
                XElement connectionStrings = XElement.Parse(xml);
                List<XAttribute> names = connectionStrings.Descendants("add").Select(x => x.Attribute("name")).ToList();
                foreach (XAttribute name in names)
                {
                    name.Value = "123";
                }
            }
     
        }
    }
