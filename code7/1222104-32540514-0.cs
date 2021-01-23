        public void AppendText(string filename, string text)
        {
            if (string.IsNullOrWhiteSpace(filename))
                throw new ArgumentException("filename cannot be null or empty");
            if (!string.IsNullOrEmpty(text))
            {
                CloudAppendBlob cab = m_BlobStorage.BlobContainer.GetAppendBlobReference(filename);
                // Create if it doesn't exist
                if (!cab.Exists())
                {
                    try
                    {
                        cab.CreateOrReplace(AccessCondition.GenerateIfNotExistsCondition(), null, null);
                    }
                    catch (StorageException) { }
                }
                // use append block as append text seems to have an error at the moment.
                using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(text)))
                {
                    cab.AppendBlock(ms);
                }
            }
            
        }
