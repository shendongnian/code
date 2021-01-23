    private void OnClick(object sender, EventArgs e)
    {
        Button btn = sender as Button; // if sender is not a Button, btn will be null
        if (btn != null)
        {
            btn.Enabled = false;
        }
    }
