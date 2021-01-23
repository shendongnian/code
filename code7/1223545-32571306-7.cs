    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    
    namespace DeserializeAzureXmlResponse
    {
        class Program
        {
            private static string thumbprint = "";
            private static string subscriptionId = "";
            static string sqlServerName = "";
    
            static string managementUri = "https://management.core.windows.net";
            static string sqlServerApi = "services/sqlservers/servers";
            static string firewallRules = "firewallrules";
    
            static void Main(string[] args)
            {
                var restUri = CreateRestUri();
                var clientCert = GetX509FromPersonalStore();
    
                var request = (HttpWebRequest)HttpWebRequest.Create(restUri);
                request.Headers.Add("x-ms-version", "2012-03-01");
                request.ClientCertificates.Add(clientCert);
    
                var response = request.GetResponse();
                var message = string.Empty;
                using (var responseStreamReader = new StreamReader(response.GetResponseStream()))
                {
                    message = responseStreamReader.ReadToEnd();
                }
    
                var textReader = new StringReader(message);
                var serializer = new XmlSerializer(typeof(ServiceResources));
                var serviceResources = serializer.Deserialize(textReader) as ServiceResources;
                if (serviceResources.Items.Count > 0)
                {
                    Console.WriteLine(serviceResources.Items.First().Name);
                }
                Console.ReadLine();
            }
    
            static Uri CreateRestUri()
            {
                // https://management.core.windows.net/{subscriptionID}/services/sqlservers/servers/{server}/firewallrules/
                var builder = new StringBuilder();
                builder.Append(managementUri + "/");
                builder.Append(subscriptionId + "/");
                builder.Append(sqlServerApi + "/");
                builder.Append(sqlServerName + "/");
                builder.Append(firewallRules + "/");
                var uri = new Uri(builder.ToString());
                return uri;
            }
    
            static X509Certificate GetX509FromPersonalStore()
            {
                // Win + R, then certmgr.msc
                var store = new X509Store(StoreLocation.CurrentUser);
                store.Open(OpenFlags.ReadOnly);
                var certificates = store.Certificates.Find(X509FindType.FindByThumbprint, thumbprint, true);
                var certificate = certificates[0];
                store.Close();
                return certificate;
            }
        }
    
        [XmlRoot(
            ElementName = "ServiceResources",
            Namespace = "http://schemas.microsoft.com/windowsazure")]
        public class ServiceResources
        {
            public ServiceResources()
            {
                Items = new List<ServiceResource>();
            }
    
            [XmlElement("ServiceResource")]
            public List<ServiceResource> Items { get; set; }
        }
    
        public class ServiceResource
        {
            [XmlElement("Name")]
            public string Name { get; set; }
            [XmlElement("Type")]
            public string Type { get; set; }
            [XmlElement("State")]
            public string State { get; set; }
            [XmlElement("SelfLink")]
            public string SelfLink { get; set; }
            [XmlElement("ParentLink")]
            public string ParentLink { get; set; }
            [XmlElement("StartIPAddress")]
            public string StartIPAddress { get; set; }
            [XmlElement("EndIPAddress")]
            public string EndIPAddress { get; set; }
        }
    }
