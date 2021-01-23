    protected void ItemBox_TextChanged(object sender, EventArgs e)
    {
        if(setFire)
        {
            SqlDataSource1.InsertCommandType = SqlDataSourceCommandType.StoredProcedure;
            string storedProcedureName = .... // The name of your stored procedure
            SqlDataSource1.InsertCommand= new SqlCommand(storedProcedureName);
            // Then you should add a SqlParameter object into the collection
            // of Parameters for the Insert Command
            // Its name correspond to the variable name expected by your
            // stored procedure and its value comes from your textbox
            string paramName = .... // The parameter name in your stored procedure
            SqlDataSource1.InsertParameters.Add(paramName, yourTextBoxName.Text);
            // Now you can call Insert()
            SqlDataSource1.Insert();
            GridView1.DataBind();
            Label1.Text = GridView1.Rows.Count.ToString() + " Results Found";
            Label2.Text = ItemBox.Text;
    
            setFire = false;
            ItemBox.Text = "";
            ItemBox.Focus();
            setFire = true;
        }
    }
