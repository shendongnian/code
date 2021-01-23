    string xml = @" <Dummy>
                    <MyInteger>1</MyInteger>
                    <MyString>dummy</MyString>
                    <MyBool>false</MyBool>
                </Dummy>";
    Dummy readDummy;
    
    XmlSchemaSet schemas = null; // here is your schema
    XmlReaderSettings settings = new XmlReaderSettings();
    settings.Schemas.Add(schemas);
    settings.ValidationType = ValidationType.Schema;
    settings.ValidationEventHandler += (s, e) =>
    {
        throw e.Exception; // Here you go
    };
    
    using (StringReader reader = new StringReader(xml))
       using (XmlReader xmlReader = XmlReader.Create(reader, settings))
           readDummy = (Dummy)serializer.Deserialize(xmlReader);
