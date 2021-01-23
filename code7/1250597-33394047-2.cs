    private void compress(System.Drawing.Image img, long quality, ImageCodecInfo codec)
    {
        EncoderParameters parameters = new EncoderParameters(1);
        parameters.Param[0] = new EncoderParameter(Encoder.Quality, quality);
    
        var ms = new MemoryStream();
        img.Save(ms, codec, parameters);
        return ms;
    }
    public void MyMethod()
    {
        MemoryStream ms;
        using(var img = Image.FromFile("myfilepath.img"))
        {
            ms = compress(img, /*quality*/, /*codec*/);
        }
        using(var compressedImage = Image.FromStream(ms))
        {
            //Use compressedImage
        }
    }
