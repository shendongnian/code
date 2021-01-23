        if (driverLicImage != null && driverLicImage.Length > 0)
        {
            byte[] knownGoodImage = System.IO.File.ReadAllBytes("Path to good file on disk");
            if (!driverLicImage.SequenceEqual(knownGoodImage))
            {
                // now you know that the bytes in the database don't match
            }
            stream = new System.IO.MemoryStream(driverLicImage, true);
            this.ucPictureEditDL.Clear();
            this.ucPictureEditDL.Image = new System.Drawing.Bitmap(stream); //Error occurs here.
        }
