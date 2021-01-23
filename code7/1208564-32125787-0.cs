    protected void btnPrevious_Click1(object sender, EventArgs e)
    {
        if (Session["ClickCount"] == null)
            Session["ClickCount"] = 0;
        int ClickCount = Convert.ToInt32(Session["ClickCount"]) + 1;
        Session["ClickCount"] = ClickCount;
        DAL.TicketsDataSetTableAdapters.TicketDetailsTableAdapter eobj = new DAL.TicketsDataSetTableAdapters.TicketDetailsTableAdapter();
        DataTable dt = new DataTable();
        eobj.GetTicketUpdates(txtSupportRef.Text);
        txtNextStep.Text = eobj.GetTicketData(txtSupportRef.Text).Rows[ClickCount - 1]["NextStep"].ToString();
    }
