     private void button1_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = open.FileName;
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }
