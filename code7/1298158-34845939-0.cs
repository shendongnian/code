    protected void btnAdd_Click(object sender, EventArgs e)
    {
        string productName = ddlName.Text;
        string quantity = tbQuantity.Text;
        string product_id = "";
        string strConnectionString = ConfigurationManager.ConnectionStrings["TrimberlandConnectionString"].ConnectionString;
        SqlConnection myConnect = new SqlConnection(strConnectionString);
        string strCommandText = "Select ID FROM Product WHERE lower(ProductName) = lower(@ProductName)";
        SqlCommand cmd = new SqlCommand(strCommandText, myConnect);
        cmd.Parameters.AddWithValue("@ProductName", productName);
        myConnect.Open();
        product_id = cmd.ExecuteScalar() == null ? "" : cmd.ExecuteScalar().ToString();
        myConnect.Close();
        if (!String.IsNullOrEmpty(product_id))
            addStocks(product_id, quantity);
    }
    private void addStocks(string productID, string quantity)
    {
        string strConnectionString = ConfigurationManager.ConnectionStrings["TrimberlandConnectionString"].ConnectionString;
        SqlConnection myConnect = new SqlConnection(strConnectionString);
        string strCommandText = "UPDATE Product SET Count = Count + @val where ID = @PID ";
        SqlCommand cmd = new SqlCommand(strCommandText, myConnect);
        cmd.Parameters.AddWithValue("@PID", productID);
        cmd.Parameters.AddWithValue("@val", quantity);
        try{
            myConnect.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Stocks have successfully been added.");
        }
        catch(Exception ex){
            //work with exception
        }
        finally{
            myConnect.Close();
        }
    }
