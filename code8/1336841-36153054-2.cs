    // Create a grayscale image
    Image<Gray, Byte> img = new Image<Gray, byte>(bmp);
    // Fill image with random values
    img.SetRandUniform(new MCvScalar(), new MCvScalar(255));
    // Create and initialize histogram
    DenseHistogram hist = new DenseHistogram(256, new RangeF(0.0f, 255.0f));
    // Histogram Computing
    hist.Calculate<Byte>(new Image<Gray, byte>[] { img }, true, null);
