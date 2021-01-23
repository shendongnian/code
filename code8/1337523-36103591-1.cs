    void setUpLayers(Control parent, int count)
    {
        for (int i = 0; i < count; i++)
        {
            PictureBox pb = new PictureBox();
            pb.BorderStyle = BorderStyle.None;
            pb.Size = parent.ClientSize;
            Bitmap bmp = new Bitmap(pb.Size.Width,pb.Size.Height,PixelFormat.Format32bppPArgb);
            pb.Image = bmp;
            pb.Parent = i == 0 ? pBox0 : Layers[i - 1];
            Layers.Add(pb);
        }
    }
