    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable dt = Rowcreation();
    
        TableRow thead = new TableRow();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            TableCell td = new TableCell();
            CheckBox chk = new CheckBox();
            chk.ID = "fund" + dt.Rows[i]["ID"];
            chk.Text = dt.Rows[i]["Name"].ToString();    
            chk.AutoPostBack = true;
            chk.CheckedChanged += new EventHandler(chk_fun_checkedchange);
            td.Controls.Add(chk);
            thead.Controls.Add(td);
        }
        pnl.Controls.Add(thead);   
    }
    
    public void chk_fun_checkedchange(object sender, EventArgs e)
    {
        DataTable dt = Rowcreation();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            CheckBox chkbx = (CheckBox ) pnl.Parent.Controls[0].FindControl("fund"+dt.Rows [i]["ID"]);
            if (chkbx.Checked == true)
            {
                lbl.Text = chkbx.Text;
            }
        }
    }
    
    private DataTable Rowcreation()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("ID");
        dt.Columns.Add("Name");
        DataRow dr = dt.NewRow();
        dr["ID"] = "1";
        dr["Name"] = "Name1";
        dt.NewRow();
        dt.Rows.Add(dr);
        
        DataRow dr1 = dt.NewRow();
        dr1["ID"] = "2";
        dr1["Name"] = "Name2";
        dt.Rows.Add(dr1);
    
        dt.NewRow();
        DataRow dr2 = dt.NewRow();
        dr2["ID"] = "3";
        dr2["Name"] = "Name3";
        dt.Rows.Add(dr2);
    
        return dt;
    }
