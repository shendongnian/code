    Button clickedButton = null;
    MouseEventArgs ee = null;
    void hitTest(Button btn, MouseEventArgs e)
    {
        Size r = btn.BackgroundImage.Size;
        // check that we have hit the image and hit a non-transparent pixel
        if ((e.X < r.Width && e.Y < r.Height) &&
                ((Bitmap)btn.BackgroundImage).GetPixel(e.X, e.Y).A != 0)
        {
            clickedButton = btn;
            ee = new MouseEventArgs(e.Button, e.Clicks, e.X + btn.Left, e.Y + btn.Top, e.Delta);
        }
        else clickedButton = null;
    }
