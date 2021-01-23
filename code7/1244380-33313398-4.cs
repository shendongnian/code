    protected void PopulateForm(int i)
    {
            DAL.TicketsDataSetTableAdapters.TicketDetailsTableAdapter eobj = new DAL.TicketsDataSetTableAdapters.TicketDetailsTableAdapter();
            DataTable dt = new DataTable();
            dt = eobj.GetTicketUpdates(txtSupportRef.Text);
                txtShortDesc.Text = dt.Rows[0].Table.Rows[i]["ShortDesc"].ToString();
                txtNextStep.Text = dt.Rows[0].Table.Rows[i]["NextStep"].ToString();
                txtLastUpdated.Text = dt.Rows[0].Table.Rows[i]["LastUpdated"].ToString();
    }
