    private void OnClick(object sender, EventArgs e)
    {
        Control ctrl = sender as Control; // if sender is not a Control, ctrl will be null
        if (ctrl != null)
        {
            ctrl .Enabled = false;
        }
    }
