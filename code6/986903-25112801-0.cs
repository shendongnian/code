    for (int i = 0; i < sFolder.Length; i++)
                    {
                        DirectoryInfo info = new DirectoryInfo(strUploadpath + sFolder[i]);
                        if (!info .Exists)
                        {
                            info.Create();
                        }
                    }
