    protected override void OnTextChanged(EventArgs e)
    {
        if (string.IsNullOrEmpty(this.Text))
            return;
        int pos = this.SelectionStart;
        if (!regex.IsMatch(Text))
        {
            this.Text = _OldValue;
            this.SelectionStart = pos > 0 ? pos - 1 : pos;
        }
        else
            _OldValue = this.Text;
        base.OnTextChanged(e);
    }
