    static void Main(string[] args)
            {
                List<Service> services;
    
                using(StreamReader file = File.OpenText("c:\\projects.xml"))
                {
                    
                    XDocument doc = XDocument.Load(file);
                    services = (from node in doc.Root.Elements("property")
                                   select new Service
                                   {
                                       serviceName = node.Attribute("name").Value,
                                       servicePath = node.Attribute("value").Value,
                                       dllFiles = System.IO.Directory.GetFiles( "servicePath", "*.dll" ),
                                   }).ToList<Service>();
            }
