    string theFileName = Path.GetFileName(YourFile.FileName);
    byte[] thePictureAsBytes = new byte[YourFile.ContentLength];
    using (BinaryReader theReader = new BinaryReader(YourFile.InputStream))
                        {
                            thePictureAsBytes = theReader.ReadBytes(YourFile.ContentLength);
                        }
    string thePictureDataAsString = Convert.ToBase64String(thePictureAsBytes);
