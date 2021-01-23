    protected void btnPrevious_Click(object sender, EventArgs e)
    {
        if (i < totalNumberOfRecords) 
        {
            i = i + 1;
            DisplayResults(i);
            LinkButton btnPrevious = (LinkButton)Master.FindControl("ContentController").FindControl("btnPreviousRecord");        btnPrevious.Enabled = true; 
     }
    }
