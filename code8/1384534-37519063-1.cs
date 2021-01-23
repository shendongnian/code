    protected void Page_Load(object sender, EventArgs e)        
    {
        AddStuff();
    }
    private void AddStuff()
    {
        TableRow thead = new TableRow();
        for (int i = 0; i < 10; i++)
        {
            TableCell td = new TableCell();
            CheckBox chk = new CheckBox();
            chk.ID = "fund_" + i;
            chk.Text = i.ToString();
            chk.AutoPostBack = true;
            chk.CheckedChanged += new EventHandler(Chk_Fund_CheckedChange);
            td.Controls.Add(chk);
            thead.Cells.Add(td);
        }
        tbl_fundtype.Rows.Add(thead);
    }
    public void Chk_Fund_CheckedChange(object sender, EventArgs e)
    {
        for (int i = 0; i < 10; i++)
        {
            var chk = tbl_fundtype.FindControl("fund_" + i) as CheckBox;
            if (chk.Checked)
            {
                //I am checked
            }
        }
    }
