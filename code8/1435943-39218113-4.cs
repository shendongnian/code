        //Rescale values between 0 and 255.
        private static void Rescale(Complex[,] convolve)
        {
            int imageWidth = convolve.GetLength(0);
            int imageHeight = convolve.GetLength(1);
            double scale = imageWidth * imageHeight;
            for (int j = 0; j < imageHeight; j++)
            {
                for (int i = 0; i < imageWidth; i++)
                {
                    double re = Math.Max(0, Math.Min(convolve[i, j].Real * scale, 255.0));
                    double im = Math.Max(0, Math.Min(convolve[i, j].Imaginary * scale, 255.0));
                    convolve[i, j] = new Complex(re, im);
                }
            }
        }
