    foreach (Control cPicture in this.Controls)
    {
        if (cPicture is PictureBox)
        {
            PictureBox miPicture = (PictureBox)cPicture;
            if (miPicture.Name == nomPicture && miPicture.Name == nomPicture)
            {
                miPicture.Image = Rec.Foto == null ? null : ConvertByteArrayToImage(Rec.Foto);
            }
        }
    }
