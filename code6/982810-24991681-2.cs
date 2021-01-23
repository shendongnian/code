    var foo = @"<?xml version=""1.0""?>
    <EDSRegisters>
      <EDSRegister>
        <RegisterAddress>0</RegisterAddress>
      </EDSRegister>
      <EDSRegister>
        <RegisterAddress>1</RegisterAddress>
      </EDSRegister>
      <EDSRegister>
        <RegisterAddress>2</RegisterAddress>
      </EDSRegister>
      <EDSRegister>
        <RegisterAddress>3</RegisterAddress>
      </EDSRegister>
    </EDSRegisters>";
    XmlSerializer serializer = new XmlSerializer(typeof(EDSRegisters));
    var bar = serializer.Deserialize(new StringReader(foo));
