    private bool fromCode;
    
    private void lbContact_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (fromCode)
           return;
        // Do the job
    }
    private void tbLast_TextChanged(object sender, EventArgs e)
    {
        fromCode = true;
        lbContact.SelectedItem = lbContact.FindString(tbLast.Text);
        fromCode = false;
    }
