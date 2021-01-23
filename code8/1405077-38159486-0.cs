    protected void Page_Load(object sender, EventArgs e)
    {
        TableRow row1 = this.CreateRow("checkBox1", "chkBox", "Row 1");
        TableRow row2 = this.CreateRow("checkBox2", "chkBox", "Row 2");
        mytbl.Rows.Add(row1);
        mytbl.Rows.Add(row2);
    }
    private TableRow CreateRow(string id, string css, string text)
    {
        var row = new TableRow();
        var cell1 = new TableCell();
        var cell2 = new TableCell { Text = text };
        var checkBox = new CheckBox
        {
            CssClass = css,
            ID = id
        };
        cell1.Controls.Add(checkBox);
        row.Cells.Add(cell1);
        row.Cells.Add(cell2);
        return row;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        foreach (TableRow row in mytbl.Rows)
        {
            CheckBox checkBox = row.Cells[0].Controls[0] as CheckBox;
            string rowText = row.Cells[1].Text;
            if(checkBox.Checked)
            {
                //Perform further processing
            }
        }
    }
