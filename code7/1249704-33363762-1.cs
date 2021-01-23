    protected void Page_Load(object sender, EventArgs e)
    {
        // Check
        if (!IsPostBack)
        {
            // Variable
            string[] product = { "Dell", "Asus", "Acer", "Toshiba", "Fujishu", "VAIO" };
            DataTable dt = new DataTable();
            dt.Columns.Add("Product");
            for (int i = 0; i < product.Length; i++)
                dt.Rows.Add(product[i]);
            gv.DataSource = dt;
            gv.DataBind();
            // Dispose
            dt.Dispose();
        }
    }
    private void DoTheMath(GridViewRow row, bool isAdd)
    {
        // Variable
        bool isNumber = false;
        int currentValue = 0;
        // Find Control
        Label lblQuantity = row.FindControl("lblQuantity") as Label;
        // Check
        if (lblQuantity != null)
        {
            // Check
            if (lblQuantity.Text.Trim() != string.Empty)
            {
                isNumber = int.TryParse(lblQuantity.Text.Trim(), out currentValue);
                // Check
                if (isNumber)
                {
                    // Is Add
                    if (isAdd)
                        currentValue++;
                    else
                    {
                        // Check cannot be less than 0
                        if (currentValue > 0)
                            currentValue--;
                    }
                }
                // Set to TextBox
                lblQuantity.Text = currentValue.ToString();
            }
        }
    }
    protected void lbtnPlus_Click(object sender, EventArgs e)
    {      
        // Get
        LinkButton lbtn = sender as LinkButton;
        GridViewRow row = lbtn.NamingContainer as GridViewRow;
        DoTheMath(row, true);
    }
    protected void lbtnMinus_Click(object sender, EventArgs e)
    {
        // Get
        LinkButton lbtn = sender as LinkButton;
        GridViewRow row = lbtn.NamingContainer as GridViewRow;
        DoTheMath(row, false);
    }
