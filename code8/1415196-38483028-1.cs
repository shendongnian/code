    public void SetLabel(string text)
    {
        this.Invoke(() =>
        {
            if (label1 != null)
                label1.Text = text;
        });
    }
