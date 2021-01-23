    SqlConnection con = new SqlConnection(ConfigurationManager.
        ConnectionStrings["ConnectionString"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DisplayCategories();
            DisplaySubCategories();
        }
    }
    
    void DisplayCategories()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "SELECT Id, Name FROM Category";
        SqlDataReader data = cmd.ExecuteReader();
        DropDownList1.DataSource = data;
        DropDownList1.DataTextField = "Name";
        DropDownList1.DataValueField = "Id";
        DropDownList1.DataBind();
        con.Close();
    }
    
    void DisplaySubCategories(string ID)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "SELECT Id, Name FROM SubCategory WHERE IdCategory = @IdCategory";
        cmd.Parameters.AddWithValue("@IdCategory", ID);
        SqlDataReader data = cmd.ExecuteReader();
        DropDownList2.DataSource = data;
        DropDownList2.DataTextField = "Name";
        DropDownList2.DataValueField = "Id";
        DropDownList2.DataBind();
        con.Close();
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        DisplaySubCategories(DropDownList2.SelectedValue);
    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        DisplayProducts(DropDownList1.SelectedValue, DropDownList2.SelectedValue);
    }
    void DisplayProducts(string mainCatID, string subCatID)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = @"SELECT productName, quantity, price FROM Product 
            WHERE MainCatID = @MainCatID AND SubCatID=@SubCatID";
        cmd.Parameters.AddWithValue("@MainCatID", mainCatID);
        cmd.Parameters.AddWithValue("@SubCatID", subCatID);
        SqlDataReader data = cmd.ExecuteReader();
        string result = string.Empty;
        while (data.Read())
        { 
            result += "Name = " + Convert.ToString(reader["productName"]) + "; ";
            result += "Quantity = " + Convert.ToString(reader["quantity"]) + "; ";
            result += "Price = " + Convert.ToString(reader["price"]);
            result += "<br />";
        }
        ReadAllOutput.Text = result;
        con.Close();
    }
