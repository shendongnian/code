    private void DisableControl(object sender)
    {
        Control ctrl = sender as Control;
        if (ctrl != null)
        {
             ctrl.Enabled = false;
        }
    }
