    Bitmap patchImages()
    {
        Bitmap bmp = new Bitmap(pictureBox1.ClientSize.Width, pictureBox1.ClientSize.Height);
        imgList.Clear();
        Random R = new Random(1);
        using (Graphics G = Graphics.FromImage(bmp) )
        {
            foreach (Image img in imageList1.Images)
            {
                // for testing: put each at a random spot
                Point pt = new Point(R.Next(333), R.Next(222));
                G.DrawImage(img, pt);
                // also add to the searchable list:
                imgList.Add(new Tuple<Image, Point>(img, pt));
            }
        }
        return bmp;
    }
