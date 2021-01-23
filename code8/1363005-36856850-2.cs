    // read from person v1
    var p1 = new PersonV1();
    p1.FirstName = "Jeff";
    p1.LastName = "Price";
    var xmlSerializer = new XmlSerializer(typeof(PersonV1));
    var stream = new MemoryStream();
    xmlSerializer.Serialize(stream, p1);
    var xmlStringP1 = Encoding.ASCII.GetString(stream.ToArray());
        
    // populate to person v2
    var deserializer = new XmlSerializer(typeof(PersonV2));
    TextReader reader = new StringReader(xmlStringP1);
    var p2 = (PersonV2)deserializer.Deserialize(reader);
    
    // further, set defaults for person v2
