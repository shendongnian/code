    protected void btnPrevious_Click1(object sender, EventArgs e)
    {
        if(stepCount == 0)
            //Ensuring that we never get into minus numbers
            stepCount = 0;
        stepCount--;
       
        DAL.TicketsDataSetTableAdapters.TicketDetailsTableAdapter eobj = new DAL.TicketsDataSetTableAdapters.TicketDetailsTableAdapter();
        DataTable dt = new DataTable();
        dt = eobj.GetTicketUpdates(txtSupportRef.Text);
        txtNextStep.Text = eobj.GetTicketData(txtSupportRef.Text).Rows[0][stepCount].ToString();
    }
    protected void btnNext_Click1(object sender, EventArgs e)
    {
        if(stepCount == 0)
            //Ensuring that we never get into minus numbers
            stepCount = 0;
        
        stepCount++;
       
        DAL.TicketsDataSetTableAdapters.TicketDetailsTableAdapter eobj = new DAL.TicketsDataSetTableAdapters.TicketDetailsTableAdapter();
        DataTable dt = new DataTable();
        dt = eobj.GetTicketUpdates(txtSupportRef.Text);
        txtNextStep.Text = eobj.GetTicketData(txtSupportRef.Text).Rows[0][stepCount].ToString();
    }
