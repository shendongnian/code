    if (BarraBlur.Value = 0)
    {
        pictureBox1.Image = imagens;  // This reestablishes the image to its original state
    }
    else {
        var blur = new Foto(imagens);   // or however the foto is constructed
        pictureBox1.Image = blur.BlurEffect(BarraBlur.Value);
    }
