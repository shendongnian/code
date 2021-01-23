       using (var stream = iso.OpenFile(name, FileMode.Open, FileAccess.Read))
                            {
                             byte[] ImgStr =  ReadFully(stream);
                             byte[] Img = TextImageEncryptionDecryption.DecryptImage(ImgStr, App.cacheKey);
                             Stream Imagestream = new MemoryStream(Img);
                             image.SetSource(Imagestream);
                             imgAttach = image;
                            }
                            return imgAttach;
                        }
