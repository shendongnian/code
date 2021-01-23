    protected void ddlEnvironemnt_SelectedIndexChanged(object sender, EventArgs e)
    {
    
        var connection = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connection))
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter adapter2 = new SqlDataAdapter();
            DataTable servers = new DataTable();
        
            cmd = new SqlCommand("sp_EnvironmentSelection", conn);
            cmd.Parameters.AddWithValue("@Environment", ddlEnvironment.SelectedValue);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            adapter2.SelectCommand = cmd;
            adapter2.Fill(servers);
        
            ddlServer.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlServer.SelectedIndex = 0;
            ddlServer.DataSource = servers;
            ddlServer.DataTextField = "ServerName";
            ddlServer.DataValueField = "ServerIP";
            ddlServer.DataBind();
        }
    }
