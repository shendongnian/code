    var xmlSerializer = new XmlSerializer(typeof(Computer));       
    using(var stringWriter = new StringWriter())
    {
        using (var xmlWriter = XmlWriter.Create(stringWriter))
        {
            xmlSerializer .Serialize(writer, computers);
            var xml = stringWriter.ToString();
            File.WriteAllText(Server.MapPath("~/App_Data/computers.xml"));
        }
    }
