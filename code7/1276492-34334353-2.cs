     byte[] ibytes = new byte[attachmentStream.Length]; 
     byte[] ImageByte = TextImageEncryptionDecryption.EncryptImage(ibytes, App.cacheKey);
      using (var store = IsolatedStorageFile.GetUserStoreForApplication())
      using (IsolatedStorageFileStream targetStream = new IsolatedStorageFileStream(selectedImageName,
                                       FileMode.Create, FileAccess.Write, store))
                        {
                            targetStream.Write(ImageByte, 0, ImageByte.Length);
                        }
