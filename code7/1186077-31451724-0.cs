                byte[] source = // some source of pdf byte array
                MemoryStream outStream = new MemoryStream();
                PdfReader reader = new PdfReader(scannedInvoice.imgImage);
                PdfStamper stamper = new PdfStamper(reader, outStream);
                for (int i = 1; i <= reader.NumberOfPages; i++)
                {
                    PdfDictionary pageDict = reader.GetPageN(i);
                    int desiredRot = 90; // 90 degrees clockwise
                    PdfNumber rotation = pageDict.GetAsNumber(PdfName.ROTATE);
                    if (rotation != null)
                    {
                        desiredRot += rotation.IntValue;
                        desiredRot %= 360; // 0, 90, 180, 270
                    }
                    pageDict.Put(PdfName.ROTATE, new PdfNumber(desiredRot));
                }
                stamper.Close();
                var rotatedpdfArray = outStream.ToArray(); // The rotated output
                
