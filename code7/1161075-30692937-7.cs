    private void button1_MouseEnter(object sender, EventArgs e)
    {
        if (button1.BackgroundImage != button1.Tag) button1.BackgroundImage.Dispose();
        button1.BackgroundImage = shade((Bitmap)(button1.Tag), Color.Orange, 3);
    }
    private void button1_MouseLeave(object sender, EventArgs e)
    {
        if (button1.BackgroundImage != button1.Tag) button1.BackgroundImage.Dispose();
        button1.BackgroundImage = (Bitmap)button1.Tag;
    }
    private void button1_MouseDown(object sender, MouseEventArgs e)
    {
        if (button1.BackgroundImage != button1.Tag) button1.BackgroundImage.Dispose();
        button1.BackgroundImage = shade((Bitmap)(button1.Tag), Color.Green, 3);
    }
    private void button1_MouseUp(object sender, MouseEventArgs e)
    {
        if (button1.BackgroundImage != button1.Tag) button1.BackgroundImage.Dispose();
        button1.BackgroundImage = shade((Bitmap)(button1.Tag), Color.Orange, 3);
    }
