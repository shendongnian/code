    DataContractSerializer serializer = new DataContractSerializer(typeof(request));
    var r = new request { version = "test" };
    using (MemoryStream ms = new MemoryStream())
    {
        serializer.WriteObject(ms, r);
        ms.Seek(0, SeekOrigin.Begin);
        using (var sr = new StreamReader(ms))
        {
            string xmlContent = sr.ReadToEnd();
            Debug.WriteLine(xmlContent);
            ms.Seek(0, SeekOrigin.Begin);
            using (XmlReader reader = XmlReader.Create(sr))
            {
                var deserialized = serializer.ReadObject(reader) as request;
                if (deserialized != null && deserialized.version == r.version)
                {
                    Debug.WriteLine("ok");
                }
            }
        }
    }
