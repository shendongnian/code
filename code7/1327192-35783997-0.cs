      public IEnumerable<String> getAllFiles(string prefix, bool slash = false) //Prefix for, slash for recur, see folders
        { 
            List<String> FileList = new List<string>();
            if (!BlobContainer.Exists()) return FileList; //BlobContainer is defined in class before this is run
            var items = BlobContainer.ListBlobs(prefix);
          
            foreach (var blob in items)
            {
                String FileName = "";
                if (blob.GetType() == typeof(CloudBlockBlob))
                {
                    FileName = ((CloudBlockBlob)blob).Name;
                    if (slash) FileName.Remove(0, 1); //remove slash if file
                    FileList.Add(FileName);
                }
                else if (blob.GetType() == typeof(CloudBlobDirectory))
                {
                    FileName = ((CloudBlobDirectory)blob).Prefix;
                    IEnumerable<String> SubFileList = getAllFiles(FileName, true);
                    foreach (String s in SubFileList)
                    {
                        FileList.Add(s);
                    }
                }
            }
            return FileList;
        }
