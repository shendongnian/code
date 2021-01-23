            private void Browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();
            if (OFD.ShowDialog() == DialogResult.OK)
            {
                Bitmap Image = new Bitmap(OFD.FileName);
                NewUserPictureBox.Image = Image;
                NewUserPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }
