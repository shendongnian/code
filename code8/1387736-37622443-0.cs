    private void btnGoTo_Click(object sender, System.Web.UI.ImageClickEventArgs e)
    {            
        string val = GoTo.Text.Trim();
        if (val.Length > 0)
        {
            PrintView.RowFilter = string.Format("Item_Number = '" + val + "'");
            PrintTable = PrintView.ToTable();
            dgPrintTicket.DataSource = PrintTable;
            dgPrintTicket.DataBind();
        }
    }
