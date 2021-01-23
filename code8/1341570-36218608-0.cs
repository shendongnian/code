    List<Bitmap> listOfBitMaps = new List<Bitmap>();
    
    foreach (string thingImLooping in ThingImLoopingThrough)
    {
        Bitmap bmp = new Bitmap(1250, 1250);
        //Do stuff to bitmap
        listofBitMaps.Add(bmp);
    }
    
    foreach (var bmp in listOfBitMaps)
    {
        // Print, process, do whatever to bmp
        bmp.Dispose();
    }
