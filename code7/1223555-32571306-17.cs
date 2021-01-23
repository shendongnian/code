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
            private static string certificateThumbprint = "19DAED4D4ABBE0D400DC33A6D99D00D7BBB24472";
            private static string subscriptionId = "14929cfc-3501-48cf-a5c9-b24a7daaf694";
            static string sqlServerName = "mvp2015";
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
                foreach (var sr in serviceResources.Items)
                {
                    Console.WriteLine("Name".PadRight(20) + sr.Name);
                    Console.WriteLine("Type".PadRight(20) + sr.Type);
                    Console.WriteLine("State".PadRight(20) + sr.State);
                    Console.WriteLine("SelfLink".PadRight(20) + sr.SelfLink);
                    Console.WriteLine("ParentLink".PadRight(20) + sr.ParentLink);
                    Console.WriteLine("StartIP".PadRight(20) + sr.StartIPAddress);
                    Console.WriteLine("EndIP".PadRight(20) + sr.EndIPAddress);
                    Console.WriteLine("+++++++++++");
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
                // To view the personal store, press `Win + R` and then type `certmgr.msc`
                var store = new X509Store(StoreLocation.CurrentUser);
                store.Open(OpenFlags.ReadOnly);
                var certificates = store.Certificates.Find(X509FindType.FindByThumbprint, certificateThumbprint, true);
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
