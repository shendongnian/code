    private void save_Click(object sender, EventArgs e)
        {
            if (pictureBox2.Image != null)
            {
                //Save First
                Bitmap varBmp = new Bitmap(pictureBox2.Image);
                Bitmap newBitmap = new Bitmap(varBmp);
                varBmp.Save(@"C:\a.png", ImageFormat.Png);
                //Now Dispose to free the memory
                varBmp.Dispose();
                varBmp = null;
            }
            else
            { MessageBox.Show("null exception"); }
        }
