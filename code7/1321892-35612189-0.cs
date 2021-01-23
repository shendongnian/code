    foreach (CloudBlobContainer item in containers)
        {
            foreach (IListBlobItem blob in item.ListBlobs()){
                blobs.Add(string.Format("{0}", blob.Uri.Segments[2]));
            }
        }
