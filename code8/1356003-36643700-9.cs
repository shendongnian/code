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
                    var definition_Ref = container.Descendants(ns + "FUNCTION-NAME-VALUE")
                        .Where(x => x.Descendants(ns + "DEFINITION-REF").Count() > 0).ToList();
                    if (definition_Ref.Count > 0)
                    {
                        string shortName = (string)container.Element(ns + "SHORT-NAME");
                        if (shortName.Length > 0)
                        {
                            List<XElement> functionName = definition_Ref
                                .Where(x => x.Value.Contains("/AUTOSAR/Com/ComConfig/ComSignal/ComTimeoutNotification"))
                                .ToList();
                            XElement value = functionName.Elements("VALUE").FirstOrDefault();
                            if (value != null)
                            {
                                value.Value = shortName + "_" + value.Value;
                            }
                        }
                    }
                }
            }
        }
    }
