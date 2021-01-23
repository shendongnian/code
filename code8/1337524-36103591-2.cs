    Random R = new Random(9);
    private void timer1_Tick(object sender, EventArgs e)
    {
        int l = R.Next(Layers.Count-1) + 1;
        Bitmap bmp = (Bitmap) Layers[l].Image;
        using (Graphics G = Graphics.FromImage(Layers[l].Image))
        {
            G.Clear(Color.Transparent);
            using (Font font = new Font("Consolas", 33f))
            G.DrawString(l + " " + DateTime.Now.Second , font, Brushes.Gold, 
                R.Next(bmp.Size.Width),  R.Next(bmp.Size.Height));
        }
        Layers[l].Image = bmp;
    }
