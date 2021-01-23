        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(picBox.Width, picBox.Height);
            picBox.DrawToBitmap(bmp, picBox.ClientRectangle);
            bmp.Save("...fileName Here...");
        }
