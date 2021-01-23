    public Example()
    {
        PictureBox box = new PictureBox();
        box.Bounds = new Rectangle(10, 10, 100, 100);
        box.Cursor = HandCursor;
        box.MouseDown += Box_MouseDown;
        box.MouseUp += Box_MouseUp;
        box.BorderStyle = BorderStyle.Fixed3D;
        Controls.Add(box);
    }
    void Box_MouseUp(object sender, MouseEventArgs e)
    {
        ((Control)sender).Cursor = HandCursor;
    }
    void Box_MouseDown(object sender, MouseEventArgs e)
    {
        ((Control)sender).Cursor = HandGrabCursor;
    }
