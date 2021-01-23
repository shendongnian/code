    if (BarraBlur.Value = 0)
    {
        pictureBox1.Image = imagens;  // This reestablishes the image to its original state
    }
    else {
        pictureBox1.Image = foto.BlurEffect(BarraBlur.Value);
    }
