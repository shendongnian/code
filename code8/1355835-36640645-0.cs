            var ser = new XmlSerializer(typeof(RequestMetaDataXml));
            var settings = new XmlSerializerNamespaces();
            settings.Add("", "");
            using (var sw = new StringWriter())
            {
                ser.Serialize(sw, o.RequestMetaDataXml, settings);
                var t = sw.ToString();
            }
