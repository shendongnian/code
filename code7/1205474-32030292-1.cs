    protected void btnConfirm_Click(object sender, EventArgs e)
    {
    
       string query = "INSERT into userPicks (Name) values (@name)";
       using (SqlConnection conn = new SqlConnection(cs))
       using (SqlCommand cmd = new SqlCommand(query, conn))
       {
           conn.Open();
           cmd.Parameters.Add("@name", SqlDbType.NVarWChar).Value = ddlGK.Text; 
           int rowsInserted = cmd.ExecuteNonQuery();
           if (rowsInserted > 0)
           {
                Response.Write("Data inserted successfully");
           }
           else
           {
                Response.Write("Data was not inserted into database");
           }
        }
    }
