    protected override void OnSizeChanged(EventArgs e)
    {
        if (this.WindowState == FormWindowState.Minimized)
        {
            //_formContextMenu or this.contextMenuStrip1
            this.contextMenuStrip1.Visible = true; 
            this.contextMenuStrip1.Close();
        }
        base.OnSizeChanged(e);
    }
