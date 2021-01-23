        public static Image CreateAnimation(Control ctl, Image[] frames, int[] delays) {
            var ms = new System.IO.MemoryStream();
            var codec = ImageCodecInfo.GetImageEncoders().First(i => i.MimeType == "image/tiff");
            EncoderParameters encoderParameters = new EncoderParameters(2);
            encoderParameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.SaveFlag, (long)EncoderValue.MultiFrame);
            encoderParameters.Param[1] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, (long)EncoderValue.CompressionLZW);
            frames[0].Save(ms, codec, encoderParameters);
            encoderParameters = new EncoderParameters(1);
            encoderParameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.SaveFlag, (long)EncoderValue.FrameDimensionPage);
            for (int i = 1; i < frames.Length; i++) {
                frames[0].SaveAdd(frames[i], encoderParameters);
            }
            encoderParameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.SaveFlag, (long)EncoderValue.Flush);
            frames[0].SaveAdd(encoderParameters);
            ms.Position = 0;
            var img = Image.FromStream(ms);
            Animate(ctl, img, delays);
            return img;
        }
