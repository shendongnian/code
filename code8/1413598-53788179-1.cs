    public MetadataSet GetRemoteMetadata(string wsdlFilePath)
    {
    	var xmlDoc = XDocument.Load(wsdlFilePath);
    	var reader = xmlDoc.CreateReader();
    	var serviceDescription = System.Web.Services.Description.ServiceDescription.Read(reader);
    	var metadataDocuments = new MetadataSection[] {
    		MetadataSection.CreateFromServiceDescription(serviceDescription)
    	};
    	return new MetadataSet(metadataDocuments);
    }
