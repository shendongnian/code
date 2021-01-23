    private List<Blob> ReturnBlobObject(O365 o365)
        {
            List<Blob> listResult = new List<Blob>();
            //Loop through all Blobs and split the container form the file name.
            foreach (var blobItem in o365.Container.ListBlobs(useFlatBlobListing: true))
            {
                string fileName = blobItem.Uri.LocalPath.Replace(string.Format("/{0}/", o365.Container.Name), "");
                string content = ReadFromBlobStream(o365.Container.GetBlobReference(fileName));
                Blob blobObject = new Blob(fileName, content);
                listResult.Add(blobObject);
            }
            return listResult; 
        }
