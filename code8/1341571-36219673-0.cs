    List<byte[]> listOfBitMaps = new List<byte[]>();
    
    foreach (string thingImLooping in ThingImLoopingThrough)
    {
        using (Bitmap bmp = new Bitmap(1250, 1250))
        {
        
            // do stuff to bitmap
            using (MemoryStream stream = new MemoryStream())
            {
                image.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
                listofBitMaps.Add(stream.ToArray());
            }
        }
    }
