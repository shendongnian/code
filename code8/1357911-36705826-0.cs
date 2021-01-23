     public sealed class IGTransparentGroupBox : GroupBox
        {
            public IGTransparentGroupBox()
            {
                SetStyle(ControlStyles.SupportsTransparentBackColor, true);
                SetStyle(ControlStyles.Opaque, true);
                BackColor = Color.Transparent;
            }
    
            protected override CreateParams CreateParams
            {
                get
                {
                    CreateParams cp = base.CreateParams;
                    cp.ExStyle = cp.ExStyle | 0x20;
                    return cp;
                }
            }
    
            protected override void OnBackColorChanged(EventArgs e)
            {
                Parent?.Invalidate(Bounds, true);
                base.OnBackColorChanged(e);
            }
    
            protected override void OnParentBackColorChanged(EventArgs e)
            {
                Invalidate();
                base.OnParentBackColorChanged(e);
            }
        }
