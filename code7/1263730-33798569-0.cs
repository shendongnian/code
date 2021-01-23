    [ProtoContract]
    class SubMessageRepresentations
    {
       [ProtoMember(5, DataFormat = DataFormat.Default)] 
       public SubObject lengthPrefixedObject;
       [ProtoMember(6, DataFormat = DataFormat.Group)]
       public SubObject groupObject;
    }
    [ProtoContract(ImplicitFields=ImplicitFields.AllFields)]
    class SubObject { public int x; }
    using (var stream = new MemoryStream()) {
      _pbModel.Serialize(
       stream, new SubMessageRepresentations {
            lengthPrefixedObject = new SubObject { x = 0x22 },
            groupObject = new SubObject { x = 0x44 }
       });
    byte[] buf = stream.GetBuffer();
    for (int i = 0; i < stream.Length; i++)
    Console.Write("{0:X2} ", buf[i]);
    }
