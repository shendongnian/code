    using (StringWriter writer = new StringWriter(CultureInfo.InvariantCulture))
    {
        XmlSerializer serializer = new XmlSerializer(typeof (Entities.Points));
        serializer.Serialize(writer, r.Datos);
        m.MarkerData = writer.ToString();
    }
