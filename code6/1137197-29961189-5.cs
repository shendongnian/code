        int argb = 255 << 24;  // we want to start with fully opaque colors!
        private void timer1_Tick(object sender, EventArgs e)
        {
           // I have move the Bitmap creation to the Form contructor
           argb += 1;
           using (Graphics G = Graphics.FromImage(pictureBox1.Image))
           {
               G.Clear(Color.FromArgb(argb));
           }
           pictureBox1.Refresh();
