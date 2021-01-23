    // use NearestNeighbor algorithm
    public static unsafe Bitmap Reduce(Bitmap source, SizeF toSize, int threadCount)
    {
        Bitmap reduced = new Bitmap((int)(toSize.Width * threadCount), (int)(toSize.Height * threadCount));
        using (Graphics g = Graphics.FromImage(reduced))
        {
            g.InterpolationMode = InterpolationMode.NearestNeighbor;
            g.DrawImage(source, new Rectangle(Point.Empty, reduced.Size));
        }
        return reduced;
    }
