        private void timer1_Tick(object sender, EventArgs e)
        {
            if(pictureBox1.Image!=null)
            {
                var img = pictureBox1.Image;  // cache it to dispose
                pictureBox1.Image = null;     // don't dispose an used object
                pictureBox1.Image.Dispose();  // and dispose of it
            }
            current = (current >= images.Length - 1) ? 0 : ++current;
            pictureBox1.Image = new Bitmap(images[current].FullName);
            pictureBox1.Refresh();
        }
