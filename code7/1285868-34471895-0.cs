    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication62
    {
        class Program
        {
            static void Main(string[] args)
            {
                string xml =
                   "<?xml version=\"1.0\" encoding=\"ISO-8859-1\" standalone=\"yes\"?>" +
                   "<INVOICE version=\"2.1\"" +
                       " xmlns=\"http://www.opentrans.org/XMLSchema/2.1\"" +
                       " xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\"" +
                       " d1p1:schemaLocation=\"http://www.opentrans.org/XMLSchema/2.1 opentrans_2_1.xsd\"" +
                       " xmlns:bmecat=\"http://www.bmecat.org/bmecat/2005\"" +
                       " xmlns:xmime=\"http://www.w3.org/2005/05/xmlmime\"" +
                       " xmlns:d1p1=\"http://www.opentrans.org/XMLSchema/2.1\">" +
                   "</INVOICE>";
                XDocument doc = XDocument.Parse(xml);
            }
        }
    }
