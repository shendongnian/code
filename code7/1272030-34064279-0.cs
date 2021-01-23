    public bool DownloadFile(string itemUrl, string localPath)
            {
                bool downloadSuccess = false;
    
                try
                {
                    using (IOFile.Stream itemFileStream = GetItemAsStream(itemUrl))
                    {
                        using (IOFile.Stream localStream = IOFile.File.Create(localPath))
                        {
                            itemFileStream.CopyTo(localStream);
                            downloadSuccess = true;
                        }
                    }
                }
                catch (Exception err)
                {
                   
                }
    
                return downloadSuccess;
            }
    protected IOFile.Stream GetItemAsStream(string itemUrl)
            {
                IOFile.Stream stream = null;
                try
                {
                    FileInformation fileInfo = File.OpenBinaryDirect(_context, itemUrl);
                    stream = fileInfo.Stream;                
                }
                catch (Exception err)
                {
                    throw new ApplicationException(string.Format("Error executing method {0}. {1}", MethodBase.GetCurrentMethod().Name, err.Message));
                }
    
                return stream;
            }
