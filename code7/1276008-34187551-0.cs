        if (openFileDialog1.ShowDialog() == DialogResult.OK)
        {
            lblFile.Text = openFileDialog1.FileName;
            // Before loading you should check the file type is an image
            if (_myImg == null)
            {
                _fileName = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString("N"));
                File.Copy(@lblFile.Text, _fileName);
                _stream = new FileStream(_fileName, FileMode.Open, FileAccess.Read);
                pictureBox1.Image = Image.FromStream(_stream);
            }
            //pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
            pictureBox1.Size = new Size(750, 1100);
            // Reset the current page when loading a new image.
            intCurrPage = 1;
            intTotalPages = pictureBox1.Image.GetFrameCount(System.Drawing.Imaging.FrameDimension.Page);
            lblNumPages.Text = intTotalPages.ToString();
            lblCurrPage.Text = "1";
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
        }
    }
    private void NextPage_btn_Click(object sender, EventArgs e)
    {
        // Directly increment the active frame within the image already in the PictureBox
        pictureBox1.Image.SelectActiveFrame(System.Drawing.Imaging.FrameDimension.Page, intCurrPage);
        if (Radio_90_Rotate.Checked)
        {
            Image Temp = pictureBox1.Image;
            Temp.RotateFlip(RotateFlipType.Rotate90FlipNone);
            pictureBox1.Image = Temp;
        }
        if (Radio_180_Rotate.Checked)
        {
            Image Temp = pictureBox1.Image;
            Temp.RotateFlip(RotateFlipType.Rotate180FlipNone);
            pictureBox1.Image = Temp;
        }
        // Refresh the PictureBox so that it will show the currently active frame
        pictureBox1.Refresh();
        if (intCurrPage <= (intTotalPages - 1))
        {
            //page increment (Go to next page)
            intCurrPage++;
        }
        lblCurrPage.Text = intCurrPage.ToString();
    }
