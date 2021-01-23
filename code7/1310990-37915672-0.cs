    public void video_NewFrame(object sender, NewFrameEventArgs EventArgs)
        {
            Invoke(new Action(() =>
                   {
                pictureBox1.Image = (Bitmap)EventArgs.Frame.Clone();
            }));
        }
