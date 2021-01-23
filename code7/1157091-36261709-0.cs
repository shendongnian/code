    public static void Register(HttpConfiguration config)
	{
			XmlDocument apiDoc = new XmlDocument();
			apiDoc.Load(HttpContext.Current.Server.MapPath("~/App_Data/VonExpy.AD.WebApi.Orders.xml"));
			XmlDocument contractsDoc = new XmlDocument();
			contractsDoc.Load(HttpContext.Current.Server.MapPath("~/App_Data/VonExpy.AD.Contracts.xml"));
			if (contractsDoc.DocumentElement != null && apiDoc.DocumentElement!=null)
			{
				XmlNodeList nodes = contractsDoc.DocumentElement.ChildNodes;
				foreach (XmlNode node in nodes)
				{
					XmlNode copiedNode = apiDoc.ImportNode(node, true);
					apiDoc.DocumentElement.AppendChild(copiedNode);
				}
				apiDoc.Save(HttpContext.Current.Server.MapPath("~/App_Data/VonExpy.AD.WebApi.Orders.xml"));
			}
			config.SetDocumentationProvider(new XmlDocumentationProvider(HttpContext.Current.Server.MapPath("~/App_Data/VonExpy.AD.WebApi.Orders.xml")));
        ......
    }
