    internal static class XmlValidationExtension {
        public static void ValidateWithWarnings( this XDocument doc, XmlSchemaSet schemas, ValidationEventHandler validationCallback ) {
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.ValidationType = ValidationType.Schema;
            settings.Schemas.Add( schemas );
            settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessSchemaLocation;
            settings.ValidationFlags |= XmlSchemaValidationFlags.ReportValidationWarnings;
            settings.ValidationEventHandler += new ValidationEventHandler( validationCallback );
            XmlReader reader = XmlReader.Create( doc.CreateReader(), settings );
            while ( reader.Read() ) ;
        }
    }
