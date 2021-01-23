    using System;
    using System.Xml.Linq;
    using Common;
    
    namespace Common
    {
        [ConnectorMetadata("Primary")]
        public class Connector : IConnector
        {
    
            public XDocument Run(object serviceCredentials, object connectorIds, object connectorKeys)
            {
                PluginsCatalog.Instance.GetConnector("Sub").Identify();
                return default(XDocument);
            }
    
            public void Identify()
            {
                Console.WriteLine(GetType().FullName);
            }
    
        }
    }
