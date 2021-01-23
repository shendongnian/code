    public new Color EllipseColor
            {
                get
                { return base.BackColor; }
                set
                {
                    if (value == base.BackColor)
                        return;
                    base.BackColor = value;
                    Invalidate();
                }
            }
