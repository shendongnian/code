                    if (FileHelper.IsFolder(info))
                    {
                        totalSize += DiskUsage.GetTotalUsage(info.FullName)
                    }
                    else
                    {
                        totalSize += info.Length;
                    }
         
                    
