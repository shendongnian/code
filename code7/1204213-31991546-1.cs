    private void OnRouteClosed (object sender, ...)
    {
        if (sender is GetDetails)
        {
            this.Controls.Remove(sender);
        }
    }
