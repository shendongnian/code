    public void InverseFFT(Complex[,] fftImage)
    {
        if (FourierTransformedImageComplex == null)
        {
           FourierTransformedImageComplex = fftImage;
        }
        GrayscaleImageComplex = FourierFunction.FFT2D(FourierTransformedImageComplex, Width, Height, -1);
        GrayscaleImageInteger = ImageDataConverter.ToInteger(GrayscaleImageComplex);
        InputImageBitmap = ImageDataConverter.ToBitmap(GrayscaleImageInteger);
    }
