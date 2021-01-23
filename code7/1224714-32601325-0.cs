    private void ButtonDisable(Control ct)
    {
        foreach(Control c in ct.Controls)
        {
            if (c is Button)
            {
               c.Enabled = false;;
            }
        }
    }
