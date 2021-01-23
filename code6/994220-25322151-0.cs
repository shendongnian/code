        public static void SaveJpegWithSpecifiedQuality(this Image image, string filename, int quality)
        {
            // http://msdn.microsoft.com/en-us/library/ms533844%28v=vs.85%29.aspx
            // A quality level of 0 corresponds to the greatest compression, and a quality level of 100 corresponds to the least compression.
            if (quality < 0 || quality > 100)
            {
                throw new ArgumentOutOfRangeException("quality");
            }
            System.Drawing.Imaging.Encoder qualityEncoder = System.Drawing.Imaging.Encoder.Quality;
            EncoderParameters encoderParams = new EncoderParameters(1);
            EncoderParameter encoderParam = new EncoderParameter(qualityEncoder, (long)quality);
            encoderParams.Param[0] = encoderParam;
            image.Save(filename, GetEncoder(ImageFormat.Jpeg), encoderParams);
        }
