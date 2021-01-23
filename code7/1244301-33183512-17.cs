    public void Foo()
    {
        Bitmap bmp = (Bitmap) panel1.BackgroundImage;
        // now do your drawing stuff
        bmp.SetPixel(...);
        panel1.BackgroundImage = bmp;
        panel1.Refresh();
    }
