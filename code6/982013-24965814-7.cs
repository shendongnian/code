    //happens when your mouse enters the region of the button.
    private void button1_MouseEnter(object sender, EventArgs e)
    {
        button1.Image = picMouseOver;
    }
    //happens when your mouse leaves the region of the button.
    private void button1_MouseLeave(object sender, EventArgs e)
    {
        button1.Image = picRegular;
    }
    //happens when your mouse button is down inside the region of the button.
    private void button1_MouseDown(object sender, MouseEventArgs e)
    {
        button1.Image = picMouseDown;
    }
    //happens when your mouse button goes up after it went down.
    private void button1_MouseUp(object sender, MouseEventArgs e)
    {
        button1.Image = picRegular;
    }
