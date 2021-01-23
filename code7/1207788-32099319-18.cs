    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    
    namespace Common
    {
        [MetadataAttribute]
        [AttributeUsage(AttributeTargets.Class)]
        public class ConnectorMetadata : ExportAttribute
        {
            public string Name { get; private set; }
    
            public ConnectorMetadata(string name):base(typeof(IConnector))
            {
                Name = name;
            }
    
            public ConnectorMetadata(IDictionary<string, object> metaData) : base(typeof (IConnector))
            {
                Name = Convert.ToString(metaData["Name"]);
            }
        }
    }
