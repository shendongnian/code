        private static Image CropImage(Image img, Rectangle cropArea)
        {
            try {
                Bitmap bmpImage = new Bitmap(img);
                Bitmap bmpCrop = bmpImage.Clone(cropArea /*your rectangle area*/, bmpImage.PixelFormat);
                return (Image)(bmpCrop);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "CropImage()");
            }
            return null;
        }
        private void saveJpeg(string path, Bitmap img, long quality)
        {
            EncoderParameter qualityParam = new EncoderParameter(
                    System.Drawing.Imaging.Encoder.Quality, (long)quality);
            ImageCodecInfo jpegCodec = getEncoderInfo("image/jpeg");
            if (jpegCodec == null)
            {
                MessageBox.Show("Can't find JPEG encoder?", "saveJpeg()");
                return;
            }
            EncoderParameters encoderParams = new EncoderParameters(1);
            encoderParams.Param[0] = qualityParam;
            img.Save(path, jpegCodec, encoderParams);
        }
        private ImageCodecInfo getEncoderInfo(string mimeType)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
            for (int i = 0; i < codecs.Length; i++)
                if (codecs[i].MimeType == mimeType)
                    return codecs[i];
            return null;
        }
        private void btnPerformSaveImage_Click(object sender, EventArgs e)
        {
            try
            {
                Image img = (Bitmap)CropImage(new Bitmap(pictureBox1.Image, pictureBox1.Size), CropRect);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "btnOK_Click()");
            }
        }
