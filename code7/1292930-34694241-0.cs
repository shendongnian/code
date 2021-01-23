    XmlDocument doc = new XmlDocument();
    doc.PreserveWhitespace = true;
    doc.Load(inputStream);
    Assembly myAssembly = Assembly.GetExecutingAssembly();
    foreach (string resource in new string[] {"message.xsd", "xmldsig-core-schema.xsd"}) {
          using (Stream schemaStream = myAssembly.GetManifestResourceStream("XmlSigTest.Resources." + resource))
          {
                 XmlSchema schema = XmlSchema.Read(schemaStream, null);
                 doc.Schemas.Add(schema);
          }
    }
    
    bool ok = true;
    doc.Validate((s, e) =>
    {
         ok = false;
    });
