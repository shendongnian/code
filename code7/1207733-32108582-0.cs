    protected void Page_Load(object sender, EventArgs e)
    {
        // Check
        if (!IsPostBack)
        {
            // Variable
            DataTable dt = new DataTable();
            dt.Columns.Add("departmentID");
            dt.Columns.Add("departmentName");
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("Dep1", "1");
            dic.Add("Dep2", "2");
            dic.Add("Dep3", "3");
            dic.Add("Dep4", "4");
            // Loop
            foreach (KeyValuePair<string, string> valuepair in dic) dt.Rows.Add(valuepair.Value, valuepair.Key);
            RadListBox1.DataSource = dt;
            RadListBox1.DataTextField = "departmentName";
            RadListBox1.DataValueField = "departmentID";
            RadListBox1.DataBind();
        }
    }
    protected void RadListBox1_ItemDataBound(object sender, RadListBoxItemEventArgs e)
    {
        // Check Count
        if (RadListBox1.Items.Count > 0)
        {
            for (int i = 0; i < RadListBox1.Items.Count; i++)
                RadListBox1.Items[i].Checked = true;
        }
    }
