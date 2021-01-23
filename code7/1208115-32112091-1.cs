    protected void Page_Load(object sender, EventArgs e)
    {
        // Check
        if (!IsPostBack)
        {
            // Variable
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            // Loop & Add ID
            for (int i = 0; i < 10; i++) dt.Rows.Add("myIDIi" + i);
            ListView1.DataSource = dt;
            ListView1.DataBind();
            
        }
    }
    protected void btn_Click(object sender, EventArgs e)
    {
        // Variable
        string value = string.Empty;
        // Loop
        foreach (ListViewItem row in ListView1.Items)
        {
            // Find Control
            CheckBox chkbox = row.FindControl("chkBox") as CheckBox;
            Label lblID = row.FindControl("lblID") as Label;
            // Check & Check Then Set to Value
            if (chkbox != null && chkbox.Checked)
                if (lblID != null) value += lblID.Text.Trim() + "<br />";
        }
        Response.Write(value);
    }
