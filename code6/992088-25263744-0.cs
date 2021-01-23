    var serializer = new XmlSerializer(typeof(DeclarationRealisation), new Type[] { typeof(Struct) });
    DeclarationRealisation result;
    using (var reader = new StreamReader("Test.xml"))
    {
        result = serializer.Deserialize(reader) as DeclarationRealisation;
    }
