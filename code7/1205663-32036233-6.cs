    void SaveHiddencontrol(Control ctl, string fileName)
    {
        Control originalParent = ctl.Parent;
        Form fff = new Form();
        fff.Opacity = 0;
        ctl.Parent = fff;
        fff.Show();
        System.Drawing.Imaging.ImageFormat fmt = System.Drawing.Imaging.ImageFormat.Jpeg;
        if (fileName.ToLower().EndsWith(".png")) fmt = System.Drawing.Imaging.ImageFormat.Png;
        using (Bitmap bmp = new Bitmap(ctl.ClientSize.Width, ctl.ClientSize.Height))
        {
            ctl.DrawToBitmap(bmp, ctl.ClientRectangle);
            bmp.Save(fileName, fmt);
        }
        ctl.Parent = originalParent;
        fff.Close();
    }
