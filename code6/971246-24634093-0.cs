    private void edTicket1_TextChanged(object sender, EventArgs e)
    {
        if (this.edTicket1.Text.Length == 5)
        {
            edTicket2.Focus();
        }
        else if (edTicket1.Text.Length > 5)
        {
            ... // What you have
        }
    }
    ...   // Repeat for other textboxes
