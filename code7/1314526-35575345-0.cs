    // Add this in the Namespace area, not inside the Page_Load function
    public bool ProcessSelectionChangedOnServer { get; set; }
    protected void ASPxGridView1_HtmlDataCellPrepared(object sender,
    DevExpress.Web.ASPxGridViewTableDataCellEventArgs e)
    {
        // if statements go here
        e.Cell.BackColor = System.Drawing.Color.LightCyan;
    }
