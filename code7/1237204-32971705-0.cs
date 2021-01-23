    public void About()
    {
        float width, height;
        using (Graphics graphics = Graphics.FromHwnd(IntPtr.Zero))
        {
            width = graphics.DpiX / 96;
            height = graphics.DpiY / 96;
        }            
        About form = new About();            
        if (width != 1 || height != 1)
            form.Scale(new SizeF(width, height));
            
        form.ShowDialog();
    }
