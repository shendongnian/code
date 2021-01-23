    /// <summary>
    ///	Validates an XML file against a given XSD schema with validation error messages.
    /// </summary>
    /// <param name="xmlFileUrl">File location of the XML file to validate.</param>
    /// <param name="xmlSchemaFile">File location of the XSD schema to validate the XML file against.</param>
    /// <param name="validationErrors">Collection of validation error information objects if the XML file violates the XSD schema.</param>
    /// <returns>True if a valid XML file according to the XSD schema, false otherwise.</returns>
    public static bool IsValidXml(
        string xmlFileUrl,
        string xmlSchemaFile,
        out IList<Tuple<object, XmlSchemaException>> validationErrors)
    {
    	var internalValidationErrors = new List<Tuple<object, XmlSchemaException>>();
    	var readerSettings = XmlSchemaReader(
            xmlSchemaFile,
    		(obj, eventArgs) => internalValidationErrors.Add(
                new Tuple<object, XmlSchemaException>(obj, eventArgs.Exception))
    	);
    
    	using (var xmlReader = new XmlTextReader(xmlFileUrl))
    	using (var objXmlReader = XmlReader.Create(xmlReader, readerSettings))
    	{
    		try
    		{
    			while (objXmlReader.Read()) { }
    		}
    		catch (XmlSchemaException exception)
    		{
    			internalValidationErrors.Add(
                    new Tuple<object, XmlSchemaException>(objXmlReader, exception));
    		}
    	}
    
    	validationErrors = internalValidationErrors;
    
    	return !validationErrors.Any();
    }
