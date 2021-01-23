    public void Foo()
    {
        Bitmap bmp = (Bitmap) panel1.BackgroundImage;
        // now do your drawing stuff
        bmp.SetPixel(R.Next(counter+22), R.Next(counter+66), Color.Red);
        panel1.BackgroundImage = bmp;
        panel1.Refresh();
    }
