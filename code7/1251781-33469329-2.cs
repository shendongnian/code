    protected void Page_Load(object sender, EventArgs e)
    {
        // CHeck
        if (!IsPostBack)
        {
            JOBRUN_CBL.Items.Add("01-SEP-2015");
            JOBRUN_CBL.Items.Add("01-AUG-2015");
            JOBRUN_CBL.Items.Add("01-JUL-2015");
            JOBRUN_CBL.Items.Add("01-JUN-2015");
        }
    }
    protected void btn_Click(object sender, EventArgs e)
    {
        // Variable
        string selectedValue = string.Empty;
        bool isDate = false;
        for (int i = 0; i< JOBRUN_CBL.Items.Count; i++)
        {
            // Check & Skip The first Index Select All
            if (i != 0)
            {
                if (JOBRUN_CBL.Items[i].Selected)
                {
                    // Convert
                    DateTime convertValue;
                    isDate = DateTime.TryParse(JOBRUN_CBL.Items[i].Value, out convertValue);
                    // Check
                    if (isDate)
                        selectedValue += JOBRUN_CBL.Items[i].Value + ",";
                }
            }
            // Reset
            isDate = false;
        }
        // Final Value Remove Last Comma
        selectedValue = selectedValue.TrimEnd(',');
        Response.Write(selectedValue);
    }
