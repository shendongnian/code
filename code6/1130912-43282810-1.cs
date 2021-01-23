    ServiceDescriptionImporter descriptionImporter = new ServiceDescriptionImporter();
    ServiceDescription serviceDescription = ServiceDescription.Read(myXmlReader);
    descriptionImporter.ProtocolName = soapVersion.ToString(); // EITHER SOAP OR SOAP12
    descriptionImporter.AddServiceDescription(serviceDescription, null, null);
    descriptionImporter.Style = ServiceDescriptionImportStyle.Client;
    descriptionImporter.CodeGenerationOptions = System.Xml.Serialization.CodeGenerationOptions.GenerateProperties;
