    Bitmap lena = inputImagePictureBox.Image as Bitmap;
    Bitmap mask = paddedMaskPictureBox.Image as Bitmap;
    Bitmap paddedLena = ImagePadder.Pad(lena, lena.Width+ mask.Width, lena.Height+ mask.Height);
    Bitmap paddedMask = ImagePadder.Pad(mask, lena.Width+ mask.Width, lena.Height+ mask.Height);
    Complex[,] cLena = ImageDataConverter.ToComplex(paddedLena);
    Complex[,] cPaddedMask = ImageDataConverter.ToComplex(paddedMask);
    Complex[,] cConvolved = Convolution.Convolve(cLena, cPaddedMask);
