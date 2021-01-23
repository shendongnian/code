    private void xxx_TextChanged(object sender, EventArgs e)
    {
        // Parse user text and convert to integer, when able:
        if ((string.IsNullOrEmpty(xxx.Text)) ||
            (!int.TryParse(xxx.Text, out yyy)))
        {
            yyy = 0;
        }
    }
