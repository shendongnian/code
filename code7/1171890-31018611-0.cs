                    HttpPostedFileBase Picture = Request.Files["Picture"];
                    Byte[] Bytes = new byte[Picture.ContentLength];
                    string ContentType = Picture.ContentType;
                    string FileName = Picture.FileName;
                    Picture.InputStream.Read(Bytes, 0, Picture.ContentLength);
