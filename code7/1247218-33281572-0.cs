       // Read a file and resize it.
       byte[] source = File.ReadAllBytes(file);
       
       using (MemoryStream inStream = new MemoryStream(source))
           using (MemoryStream outStream = new MemoryStream())
               using (ImageFactory imageFactory = new ImageFactory())
               {
                   // Load, remove whitespace around image and save an image.
                   imageFactory.Load(inStream)
                        .EntropyCrop()
                        .Save(outStream);
    
                } 
            }
        }
