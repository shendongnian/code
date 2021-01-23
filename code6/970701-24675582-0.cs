    void MyUserControl_VisibleChanged(object sender, EventArgs e)
    {
        UserControl us = sender as UserControl;
        this.BeginInvoke(new Action(() => {
            if (us.Visible)
            {
                CustomCommand();
            }
        });
    }
