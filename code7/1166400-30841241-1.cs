    private void disableButtons()
    {
        try
        {
            foreach (Control c in Controls)
            {
                Button b = (Button)c;
                b.Enabled = false;
            }
        }
        catch { }
    }
