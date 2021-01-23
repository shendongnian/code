    protected override void OnSizeChanged(EventArgs e)
    {
        if (AllowAutoScroll)
        {
            if (SystemFonts.DefaultFont.Size < 8)
            {
                this.AutoScroll = true;
            }
            if (this.Handle != null)
            {
                this.BeginInvoke((MethodInvoker) delegate
                {
                    base.OnSizeChanged(e);
                });
            }
        }
    }
