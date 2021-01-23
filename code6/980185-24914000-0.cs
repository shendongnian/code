    protected void Page_Load(object sender, EventArgs e)
    {
        string[] tableHeaders = { // blah blah };
   
        foreach(var header in tableHeaders)
        {
            var tmp = new TableHeaderCell();
            tmp.ID = "TH_" + header;
            tmp.Text = header;
            headerRow.Cells.Add(tmp);
        }
    }
