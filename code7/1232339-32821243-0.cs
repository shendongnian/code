    private bool fullScreen = false;
    [DefaultValue(false)]
    public bool FullScreen
    {
        get
        {
            return fullScreen;
        }
        set
        {
            fullScreen = value;
            if (value)
            {
                this.SuspendLayout();
                this.WindowState = FormWindowState.Normal;
                FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                WindowState = FormWindowState.Maximized;
                this.ResumeLayout(true);
            }
            else
            {
                this.Activate();
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            }
        }
    }
