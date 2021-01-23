    protected void Page_Load(object sender, EventArgs e)
    {
        // Check
        if (!IsPostBack)
        {
            // Variable
            string[] text = { "A","B","C", "D", "E", "F" };
            DataTable dt = new DataTable();
            dt.Columns.Add("Text");
            dt.Columns.Add("Value");
            // Add Rows
            for (int i = 0; i < text.Length; i++)
                dt.Rows.Add(text[i], i + "");
            // Bind to Drop Down
            rcb.DataSource = dt;
            rcb.DataTextField = "Text";
            rcb.DataValueField = "Value";
            rcb.DataBind();
            // Check
            if (rcb.Items.Count > 0)
            {
                rcb.SelectedValue = "3";
                rcb_SelectedIndexChanged(rcb, new RadComboBoxSelectedIndexChangedEventArgs
                (rcb.SelectedItem.Text.Trim(), "", rcb.SelectedValue, "")); 
                // Trigger Selected Index Changed
            }
        }
    }
    protected void rcb_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        // Check if the dropdown is selectedIndex is greater or equal first item
        // if you have "Please select" on first item just change ">=" to ">"
        if (rcb.SelectedIndex >= 0)
        {
            lbl.Text = rcb.SelectedItem.Text.Trim();
        }
    }
