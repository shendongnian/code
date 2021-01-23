    var meta = new System.ServiceModel.Description.MetadataExchangeClient(new Uri("net.tcp://10.0.2.124:9000/TeraService/SetInstruments/mex"), System.ServiceModel.Description.MetadataExchangeClientMode.MetadataExchange);
    var data = meta.GetMetadata();
    System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(data.GetType());
    TextWriter writer = new StreamWriter("xmlfile.xml");
    x.Serialize(writer, data);
    writer.Close();
