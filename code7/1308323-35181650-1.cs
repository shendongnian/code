    namespace WcfServices
    {
        public class CDNManagementService : ICDNManagementService
        {
            BlobInformation _blobInformation = new BlobInformation();
    
            public void SetBlobInformation(BlobInformation blobinformation)
            {
                Logger.Log("azureBlobUrl= " + blobinformation.azureBlobUrl);
                Logger.Log("Before SetBlobInformation: " + _blobInformation.azureBlobUrl);
                _blobInformation = blobinformation;
                Logger.Log("After SetBlobInformation: " + _blobInformation.azureBlobUrl);
    
            }
    
            public BlobInformation GetBlobInformation()
            {
                Logger.Log("In GetBlobInformation: " + _blobInformation.azureBlobUrl);
                return _blobInformation;            
    
            }
        }
    }
