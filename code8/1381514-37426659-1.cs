    var config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration(Request.ApplicationPath);
    var section = config.GetSection("system.webServer");
    var xml = section.SectionInformation.GetRawXml();
    var doc = XDocument.Parse(xml);
    var element = doc.Root.Element("security").Element("requestFiltering").Element("requestLimits");
    var maxUrl = element.Attribute("maxUrl").Value;
    var maxQs = element.Attribute("maxQueryString").Value;
