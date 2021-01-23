    bool isDrag = false;
    int lastY = 0;
    private void textBox1_MouseEnter(object sender, EventArgs e)
    {
        //Change cursor to dragging handle or implement a pop-up
    }
    private void textBox1_MouseDown(object sender, MouseEventArgs e)
    {
        //Just add 5px padding
        if (e.Y >= (textBox1.ClientRectangle.Bottom - 5) &&
            e.Y <= (textBox1.ClientRectangle.Bottom + 5))
        {
            isDrag = true;
            lastY = e.Y;
        }
    }
    private void textBox1_MouseMove(object sender, MouseEventArgs e)
    {
        if( isDrag)
        {
            textBox1.Height += (e.Y - lastY);
            lastY = e.Y;
        }
    }
    private void textBox1_MouseUp(object sender, MouseEventArgs e)
    {
        if (isDrag)
        {
            isDrag = false;
        }
    }
