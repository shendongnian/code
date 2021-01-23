    MouseButtons btns = MouseButtons.None;
    private void listView1_MouseDown(object sender, MouseEventArgs e)
    {
        btns = Control.MouseButtons;
    }
    private void listView1_MouseEnter(object sender, EventArgs e)
    {
        btns = Control.MouseButtons;
    }
    private void listView1_MouseUp(object sender, MouseEventArgs e)
    {
        if (btns != e.Button) return;
    }
