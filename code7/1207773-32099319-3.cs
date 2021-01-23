    using System.Xml.Linq;
    
    namespace Common
    {
        public interface IConnector
        {
            XDocument Run(object serviceCredentials, object connectorIds, object connectorKeys);
    
            void Identify();
        }
    }
