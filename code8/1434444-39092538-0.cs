    public static Bitmap ByteToImage(byte[] blob)
            {
                Bitmap bm = (Bitmap)((new ImageConverter()).ConvertFrom(blob));
                return bm;
            }
