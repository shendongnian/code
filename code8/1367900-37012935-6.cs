    public static class XNodeExtensions
    {
        public static void Validate(this XContainer node, XmlReaderSettings settings)
        {
            if (node == null)
                throw new ArgumentNullException();
            using (var innerReader = node.CreateReader())
            using (var reader = XmlReader.Create(innerReader, settings))
            {
                while (reader.Read())
                    ;
            }
        }
        public static void Validate(this XContainer node, XmlSchemaSet schemaSet, XmlSchemaValidationFlags validationFlags, ValidationEventHandler validationEventHandler)
        {
            var settings = new XmlReaderSettings();
            settings.ValidationType = ValidationType.Schema;
            settings.ValidationFlags |= validationFlags;
            if (validationEventHandler != null)
                settings.ValidationEventHandler += validationEventHandler;
            settings.Schemas = schemaSet;
            node.Validate(settings);
        }
    }
