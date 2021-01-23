        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(picBox.ClientSize.Width, picBox.ClientSize.Height);
            picBox.DrawToBitmap(bmp, picBox.ClientRectangle);
            bmp.Save("...fileName Here...");
        }
