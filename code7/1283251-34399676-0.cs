        static void Main(string[] args)
        {
            string[] xmls = { @"<vxml application=""notsupported"" lang=""en-US""     base=""http://www.zebra.com"">
       <unknow></unknow>
      </vxml>",
            @"<vxml application=""notsupported"" lang=""en-US""     base=""http://www.zebra.com"" xmlns=""http://example.com/ns1"">
       <unknow></unknow>
      </vxml>"
                            };
            foreach (string xml in xmls)
            {
                Console.WriteLine("Validating");
                Validate(xml, "../../schema1.xml");
                Console.WriteLine();
            }
        }
        static void Validate(string xmlMarkup, string schemaUri)
        {
            XmlReaderSettings xrs = new XmlReaderSettings();
            xrs.Schemas.Add(null, schemaUri);
            xrs.ValidationType = ValidationType.Schema;
            xrs.ValidationFlags |= XmlSchemaValidationFlags.ReportValidationWarnings;
            xrs.ValidationEventHandler += (obj, valArgs) =>
            {
                Console.WriteLine("{0}: {1}", valArgs.Severity, valArgs.Message);
            };
            using (StringReader sr = new StringReader(xmlMarkup))
            {
                using (XmlReader xr = XmlReader.Create(sr, xrs))
                {
                    while (xr.Read()) { }
                }
            }
        }
