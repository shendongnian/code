    public new string Text
    {
        get { return base.Text; }
        set
        {
            if (base.Text != value)
            {
                 base.Text = value;
                 OnTextChanged(EventArgs.Empty);
            }
        }
    }
