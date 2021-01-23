    private void clickPanel_MouseClick(object sender, MouseEventArgs e)
    {
        if (((Bitmap)clickPanel.BackgroundImage).GetPixel(e.X, e.Y).A == 0)
        {
            MouseEventArgs ee = new MouseEventArgs(e.Button, 
                                e.Clicks,e.X + clickPanel.Left, e.Y + clickPanel.Top, e.Delta) ;
            pictureBox1_MouseClick(pictureBox1, ee);
        }
        else doYourClickStuff();
        
    }
