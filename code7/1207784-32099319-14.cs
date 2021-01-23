    using System;
    using System.Xml.Linq;
    using Common;
    
    namespace SubPlugin
    {
        [ConnectorMetadata("Sub")]
        public class SubConnector:IConnector
        {
            public XDocument Run(object serviceCredentials, object connectorIds, object connectorKeys)
            {
                return default(XDocument);
            }
    
            public void Identify()
            {
                Console.WriteLine(GetType().FullName);
            }
        }
    }
