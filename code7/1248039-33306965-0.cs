    public MemoryStream Base64ToJpeg(string imgFoto)
    {
        Image imagemASerAjustada = null;
        Bitmap bmpTemporario = null;
        MemoryStream imagemCompactadaStream = new MemoryStream();
        EncoderParameters myEncoderParameters = new EncoderParameters(1);
        try
        {
            // removemos o cabeçalho a respeito do tipo da imagem
            string base64 = imgFoto.Substring(imgFoto.IndexOf(',') + 1);
            base64 = base64.Trim('\0');
            // convertemos em um array de bytes
            byte[] img = Convert.FromBase64String(base64);
            
            // transformamos a base64 em imagem
            imagemASerAjustada = Image.FromStream(new MemoryStream(img));
            // convertemos a imagem em Bitmap
            bmpTemporario = new Bitmap(imagemASerAjustada, new Size(140, 140));
            ImageCodecInfo jpgEncoder = GetEncoder(ImageFormat.Jpeg);
            // Create an EncoderParameters object.
            // An EncoderParameters object has an array of EncoderParameter
            // objects. In this case, there is only one
            // EncoderParameter object in the array.
            Encoder myEncoder = Encoder.Quality;
            using (EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 80L))
            { 
                myEncoderParameters.Param[0] = myEncoderParameter;
                bmpTemporario.Save(imagemCompactadaStream, jpgEncoder, myEncoderParameters);
            }
            return imagemCompactadaStream;
        }
        catch
        {
            throw;
        }
        finally
        {
            if (imagemCompactadaStream.Length > 0)
            { 
                imagemASerAjustada.Dispose();
                bmpTemporario.Dispose();
                myEncoderParameters.Dispose();
            }
        }
    }
    
