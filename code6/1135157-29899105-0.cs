    void ChangeImageOpacity(int opacity,string image_path)
    {
        if (this.InvokeRequired)
        {
            this.BeginInvoke(new Action<int, string>(ChangeImageOpacity), new object[] { opacity, image_path });
        }
        else
        {
            this.Image = ImageOperation.ChangeImageOpacity(image_path, opacity);
            Application.DoEvents();
        }
    }
