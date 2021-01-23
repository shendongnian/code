    puplic void BringToTop()
    {
        if (this.InvokeRequired)
        {
            this.Invoke(new Action(BringToTop));
        }
        else
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            bool top = TopMost;
            TopMost = true;
            TopMost = top;
        }
    }
