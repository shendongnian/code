    private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
    {
        int found = -1;
        // I search backward because I drew forward:
        for (int i = imageList1.Images.Count - 1; i >= 0; i--)
        {
            Bitmap bmp = (Bitmap) imgList[i].Item1;
            Point  pt = (Point) imgList[i].Item2;
            Point pc = new Point(e.X - pt.X, e.Y - pt.Y);
            Rectangle bmpRect = new Rectangle(pt.X, pt.Y, bmp.Width, bmp.Height);
            // I give a little slack (11) but you could also check for > 0!
            if (bmpRect.Contains(e.Location) && bmp.GetPixel(pc.X, pc.Y).A > 11)
               { found = i; break; }
        }
        // do what you want with the found image..
        // I show the image in a 2nd picBox and its name in the form text:
        if (found >= 0) { 
            pictureBox2.Image = imageList1.Images[found];
            Text = imageList1.Images.Keys[found];
        }
    }
