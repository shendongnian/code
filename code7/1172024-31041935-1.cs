    protected void rlb_ItemDataBound(object sender, RadListBoxItemEventArgs e)
    {
        const int maxLength = 8;
        if (e.Item.Text.Length <= maxLength) return;
        e.Item.ToolTip = e.Item.Text;
        e.Item.Text = string.Format("{0}...", e.Item.Text.Substring(0, maxLength));
    }
