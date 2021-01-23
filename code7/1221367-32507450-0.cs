    private void Convert()
    {        
        OpenFileDialog op = new OpenFileDialog();
        op.InitialDirectory = "D:/";
        op.Filter = "All Files|*.*|JPEGs|*.jpg|Bitmaps|*.bmp|GIFs|*.gif";
        op.FilterIndex = 1;
        if (op.ShowDialog() == DialogResult.OK)
        {
            pictureBox3.Image = Image.FromFile(op.FileName);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.BorderStyle = BorderStyle.Fixed3D;
            Bitmap img = new Bitmap(op.FileName);
            StringBuilder t = new StringBuilder();
            for (int i = 0; i < img.Width; i++)
            {
                for (int j = 0; j < img.Height; j++)
                {
                        t.Append((img.GetPixel(i, j).R > 100 && img.GetPixel(i, j).G > 100 &&
                                 img.GetPixel(i, j).B > 100) ? 0 : 1);
                }
                t.AppendLine();
            }
            textBox1.Text = t.ToString();
        }
    }
