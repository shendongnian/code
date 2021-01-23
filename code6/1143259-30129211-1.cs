    public static void Execute()
    {
      var xml = @"
        <Slot name='urn:ihe:iti:xds:2013:referenceIdList'>
          <ValueList>
            <Value>123456^^^&amp;orgID&amp;ISO^urn:ihe:iti:xds:2013:referral</Value>
            <Value>098765^^^&amp;orgID&amp;ISO^urn:ihe:iti:xds:2013:referral</Value>
          </ValueList>
        </Slot>
      ";
      var reader = System.Xml.XmlReader.Create(new System.IO.StringReader(xml));
      for (; ; )
      {
        if (!reader.Read())
          break;
        if (reader.NodeType == System.Xml.XmlNodeType.Text)
          Console.WriteLine(reader.Value);
      }
    }
