    protected override void OnSizeChanged(EventArgs e)
    {
        if (this.WindowState == FormWindowState.Minimized)
        {
            this.contextMenuStrip1.Visible = true;
            this.contextMenuStrip1.Close();
        }
        base.OnSizeChanged(e);
    }
