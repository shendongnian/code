    private void Form1_MouseClick(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Right)
        {
            // new instance of class
            MenuUserControl usrCtrl = new MenuUserControl();
            usrCtrl.ToggleIsCollapsed();
        }
    }
