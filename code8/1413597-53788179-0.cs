    public MetadataSet GetRemoteMetaData(string wsdlFilePath)
    {
    	var metadataDocuments = new List<MetadataSection>();
    	var xmlDoc = XDocument.Load(wsdlFilePath);
    	var reader = xmlDoc.CreateReader();
    	var serviceDescription = System.Web.Services.Description.ServiceDescription.Read(reader);
    	metadataDocuments.Add(MetadataSection.CreateFromServiceDescription(serviceDescription));
    	return new MetadataSet(metadataDocuments);
    }
