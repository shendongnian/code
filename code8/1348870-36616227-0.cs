    Image<Gray, Byte> croppedImage = sourceImage.Copy();
    
    DenseHistogram hist1 = new DenseHistogram(256, new RangeF(0.0f, 255.0f));
    hist1.Calculate<Byte>(new Image<Gray, byte>[] { croppedImage }, true, null);
    
    Mat matFromHistogram = new Mat(hist1.Size, hist1.Depth, hist1.NumberOfChannels, hist1.DataPointer, hist1.Step);
                                
    byte[] histogramBytes;
    
    using (MemoryStream stream = new MemoryStream())
    {
    	BinaryFormatter bformatter = new BinaryFormatter();
    	bformatter.Serialize(stream, matFromHistogram);
    	histogramBytes = stream.GetBuffer();
    }
