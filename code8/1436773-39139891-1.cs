    private void picAndpnl_MouseEnter(object sender, EventArgs e)
    {
        // check if this is the PictureBox or the Panel
        var ctl = (Control)sender;
        if (ctl is PictureBox)
        {
            ctl = ctl.Parent;
        }
        Button bt1 = (Button)ctl.Controls[0];
        Button bt2 = (Button)ctl.Controls[1];
        bt1.Show();
        bt2.Show();
    }
