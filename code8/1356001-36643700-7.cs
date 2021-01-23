    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication85
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                XNamespace ns = ((XElement)doc.FirstNode).Name.Namespace;
                List<XElement> containers = doc.Descendants(ns + "CONTAINER").ToList();
                foreach (XElement container in containers)
                {
                    XElement definition_Ref = container.Descendants(ns + "DEFINITION-REF")
                        .Where(x => x.Value.Contains("/AUTOSAR/Com/ComConfig/ComSignal/ComTimeoutNotification"))
                        .FirstOrDefault();
                    if (definition_Ref != null)
                    {
                        string shortName = (string)container.Element(ns + "SHORT-NAME");
                        if (shortName.Length > 0)
                        {
                            List<XElement> values = container.Descendants(ns + "FUNCTION-NAME-VALUE").Descendants(ns + "VALUE").ToList();
                            foreach (XElement value in values)
                            {
                                value.Value = shortName + "_" + value.Value;
                            }
                        }
                    }
                }
            }
        }
    }
