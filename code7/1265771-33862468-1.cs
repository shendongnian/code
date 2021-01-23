    protected void Page_Load(object sender, EventArgs e)
    {
        // Check
        if (!IsPostBack)
        {
            // Variable
            DataTable dt = new DataTable();
            dt.Columns.Add("Count");
            // Loop
            for (int i = 0; i < 11; i++)
                dt.Rows.Add(i);
            // Bind to Drop Down
            ddl.DataSource = dt;
            ddl.DataTextField = "Count";
            ddl.DataValueField = "Count";
            ddl.DataBind();
            // Dispose
            dt.Dispose();
        }
    }
    protected void ddl_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Variable
        int myPool = 0;
        int mySelectedValue = 0;
        int result = 0;
        int dropDownValue = 0;
        bool isInteger = false;
        // Parse Integer
        int.TryParse(hf.Value, out myPool);
        int.TryParse(ddl.SelectedValue, out mySelectedValue);
        // Set Result
        result = myPool - mySelectedValue;
        // Set to Hidden Value & Label
        hf.Value = result + "";
        lbl.Text = result + "";
        for (int i = 0; i < ddl.Items.Count; i++)
        {
            // Reset
            isInteger = false;
            dropDownValue = 0;
            // Parse Drop Down Value
            isInteger = int.TryParse(ddl.Items[i].Value, out dropDownValue);
            // Check
            if (isInteger)
            {
                // Ensure is not less than 0, If less than 0 disabled the selected value
                if ((result - dropDownValue) < 0)
                    ddl.Items[i].Attributes.Add("disabled", "true");
            }
        }
    }
