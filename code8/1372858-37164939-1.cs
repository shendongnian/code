        if (driverLicImage != null && driverLicImage.Length > 0)
        {
            try
            {
                stream = new System.IO.MemoryStream(driverLicImage, true);
                this.ucPictureEditDL.Clear();
                this.ucPictureEditDL.Image = new System.Drawing.Bitmap(stream); //Error occurs here.
            }
            catch (ArgumentException ex)
            {
                System.Diagnostics.Debug.Print(ex.Message);
                System.IO.File.WriteAllBytes("Filename", driverLicImage);
            }
        }
    Of course you will want to choose an appropriate file name. 
