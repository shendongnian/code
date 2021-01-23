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
        lbContact.SetSelected(lbContact.FindString(tbLast.Text), true);
        fromCode = false;
    }
