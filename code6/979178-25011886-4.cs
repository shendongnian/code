    using System.ServiceModel.Channels;
    using System.ServiceModel.Description;
    using System.ServiceModel.Dispatcher;
    using System.Xml.Schema;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            class XsdValidationInspector : IClientMessageInspector ... //omitted for clarity
            class XsdValiationBehavior : IEndpointBehavior ... //omitted for clarity
    
            static void Main(string[] args)
            {
                ContractDescription cd = ContractDescription.GetContract(typeof(ServiceReference1.IService1));
    
                WsdlExporter exporter = new WsdlExporter();
    
                exporter.ExportContract(cd);
    
                XmlSchemaSet set = exporter.GeneratedXmlSchemas;
    
                // Client implementation omitted for clarity sake.
                var client = <some client here>; //omitted for clarity
                    
                var validation = new XsdValidationBehavior(new XmlSchemaSet { xmlSchema });
                    
                client.ChannelFactory.Behaviours.Add(validation);
            }
        }
    }
