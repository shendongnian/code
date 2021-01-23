    TableCell cel2 = new TableCell();
    Label lbl2 = new Label();
    lbl2.Text = s;
    cel2.Controls.Add(lbl2);
    tr.Cells.Add(cel2);
    TableCell cel3 = new TableCell();
    DropDownList ddlcountry = new DropDownList();
    ddlcountry.ID = s;
    cel3.Controls.Add(ddlcountry);
    tr.Cells.Add(cel3);
    table.Rows.Add(tr);
    form1.Controls.Add(table);
    DropDownList ddl1 = (DropDownList)form1.FindControl("CountryId");
    DropDownList ddlstate = (DropDownList)form1.FindControl("StateId");
    ddl1.AutoPostBack = true;
    ddl1.SelectedIndexChanged += new EventHandler(ddl1_SelectedIndexChanged);
    protected void ddl1_SelectedIndexChanged(object sender, EventArgs e)
    {
    }
