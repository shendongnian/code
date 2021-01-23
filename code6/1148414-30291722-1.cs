    using System.Xml;
    internal class XmlExample
    {
        /// <summary>
        /// Takes an XML string and removes complaint nodes with an ID of 2.
        /// </summary>
        /// <param name="xml">An XML document in string form.</param>
        /// <returns>The XML document with nodes removed.</returns>
        public static string StripComplaints(string xml)
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.LoadXml(xml);
            XmlNodeList nodes = xdoc.SelectNodes("/complaints/complaint[ID = '2']");
            XmlNode complaintsNode = xdoc.SelectSingleNode("/complaints");
            foreach (XmlNode n in nodes)
            {
                complaintsNode.RemoveChild(n);
            }
            return xdoc.OuterXml;
        }
    }
