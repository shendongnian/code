    protected DataTable GetData(string supportRef)
    {
        DAL.TicketsDataSetTableAdapters.TicketDetailsTableAdapter eobj = new DAL.TicketsDataSetTableAdapters.TicketDetailsTableAdapter();
        return eobj.GetTicketUpdates(supportRef);
    }
    protected void PopulateForm(int i)
    {
        ViewState["recordIndex"] = i
        System.Data.DataRow row = dt.Rows[0].Table.Rows[i];
        txtShortDesc.Text = row["ShortDesc"].ToString();
        txtNextStep.Text = row["NextStep"].ToString();
        txtLastUpdated.Text = row["LastUpdated"].ToString();
    }
