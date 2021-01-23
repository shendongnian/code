    public string CreateSharedAccessSignature(string blobUri, int timeout, TimeUnitType timeUnit)
        {
            try
            {
                var uri = new Uri(blobUri);
                var cloudBlob = _context.CloudBlobClient.GetBlobReferenceFromServer(uri);
   
                if (!cloudBlob.Exists())
                {
                    throw new StorageException("Blob does not exist");
                }
                var sasConstraints = new SharedAccessBlobPolicy
                {
                    SharedAccessStartTime = DateTime.UtcNow.AddMinutes(-5),
                    Permissions = SharedAccessBlobPermissions.Read
                };
                //The shared access signature will be valid immediately.
                switch(timeUnit)
                {
                    case TimeUnitType.Days:
                        sasConstraints.SharedAccessExpiryTime = DateTime.UtcNow.AddDays(timeout);
                        break;
                    case TimeUnitType.Hours:
                        sasConstraints.SharedAccessExpiryTime = DateTime.UtcNow.AddHours(timeout);
                        break;
                    case TimeUnitType.Minutes:
                        sasConstraints.SharedAccessExpiryTime = DateTime.UtcNow.AddMinutes(timeout);
                        break;
                    case TimeUnitType.Seconds:
                        sasConstraints.SharedAccessExpiryTime = DateTime.UtcNow.AddSeconds(timeout);
                        break;
                }
                
                //Generate the shared access signature on the blob, setting the constraints directly on the signature.
                string sasBlobToken = cloudBlob.GetSharedAccessSignature(sasConstraints);
                return cloudBlob.Uri + sasBlobToken;
            }
            catch(Exception ex)
            {
                //new RaygunClient().Send(ex);
                throw;
            }
        }
