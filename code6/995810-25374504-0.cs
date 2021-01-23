    using System.Configuration;
    using System.ServiceModel.Configuration;
    using config = System.Configuration.Configuration;
    namespace Client
    {
        public class Program
        {
            private static void Main(string[] args)
            {
                config Config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                ServiceModelSectionGroup Group = ServiceModelSectionGroup.GetSectionGroup(Config);
                BehaviorsSection Behaviors = Group.Behaviors;
                EndpointBehaviorElementCollection EndpointBehaviors = Behaviors.EndpointBehaviors;
                EndpointBehaviorElement EndpointBehavior = EndpointBehaviors[0];
                ClientCredentialsElement ClientCredential = (ClientCredentialsElement) EndpointBehavior[0];
                var ClientCertificate = ClientCredential.ClientCertificate;
            
                var findValue = ClientCertificate.FindValue;
                var storeName = ClientCertificate.StoreName;
                var storeLocation = ClientCertificate.StoreLocation;
                var X509FindType = ClientCertificate.X509FindType;
            }
        }
    }
