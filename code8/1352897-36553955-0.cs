    private void SaveJpg(Image image, string file_name, long compression)
    {
        try
        {
            EncoderParameters encoder_params = new EncoderParameters(1);
            encoder_params.Param[0] = new EncoderParameter(
                System.Drawing.Imaging.Encoder.Quality, compression);
    
            ImageCodecInfo image_codec_info =
                GetEncoderInfo("image/jpeg");
            File.Delete(file_name);
            using(var imageStream = new Stream()){
                // save to stream
                image.Save(imageStream, image_codec_info, encoder_params);
                // upload
                UploadImageToAmazon(imageStream);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error saving file '" + file_name +
                "'\nTry a different file name.\n" + ex.Message,
                "Save Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }
