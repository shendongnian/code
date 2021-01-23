    private void theOtherPlace_MouseMove(object sender, MouseEventArgs e)
    {
        if (! theOtherPlace.ClientRectangle.Contains(e.Location))
        {
            User32_DLL.ReleaseCapture();
        }
    }
