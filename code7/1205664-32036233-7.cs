    void SaveHiddencontrol(Control ctl, string fileName)
    {
        Control originalParent = ctl.Parent;
        int oldLeft = ctl.Left;
        ctl.Left = 22222;  // way outside
        ctl.Parent = this;
        System.Drawing.Imaging.ImageFormat fmt = System.Drawing.Imaging.ImageFormat.Jpeg;
        if (fileName.ToLower().EndsWith(".png")) fmt = System.Drawing.Imaging.ImageFormat.Png;
        using (Bitmap bmp = new Bitmap(ctl.ClientSize.Width, ctl.ClientSize.Height))
        {
            ctl.DrawToBitmap(bmp, ctl.ClientRectangle);
            bmp.Save(fileName, fmt);
        }
        ctl.Parent = originalParent;
        ctl.Left = oldLeft;
    }
