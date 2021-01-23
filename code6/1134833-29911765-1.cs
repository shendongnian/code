    int opacity = 0;
    private void tmrFadeOut_Tick(object sender, EventArgs e)
    {
    if (opacity < 255)
    {
        Image img = myImage.Image;
        using (Graphics g = Graphics.FromImage(img))
        {
            Pen pen = new Pen(Color.FromArgb(opacity, 255, 255, 255), img.Width);
            g.DrawLine(pen, -1, -1, img.Width, img.Height);
            g.Save();
        }
        myImage.Image = img;
        opacity++;
    }
    else
    {
        timer1.Stop();
    }
    }
