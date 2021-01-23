    var builder = new ContainerBuilder();
    var xmlFileName = HttpContext.Current.Server.MapPath(
        ConfigurationManager.AppSettings["xmlData"]);
    builder.Register(c => new XmlAdvertisementRepository(new XmlContext(xmlFileName)))
        .AsImplementedInterfaces()
        .InstancePerHttpRequest();
