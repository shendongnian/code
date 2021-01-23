            if (pictureBox1.ImageLocation != null)
            {
                Properties.Settings.Default.ImageLocation = pictureBox1.ImageLocation;
                Properties.Settings.Default.Save();
            }
