    public Bitmap streamimage(string Fname)
    {
        Bitmap bm;
        FileStream stream = new FileStream(Fname, FileMode.Open, FileAccess.Read);
        bm = (Bitmap)Image.FromStream(stream);
        return bm;
    }
