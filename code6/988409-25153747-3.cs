    DataTable dt = new DataTable();
    String conStr = "Data Source=172.16.6.173;Initial Catalog=servion_hari;User  ID=sa;Password=Servion@123";
    SqlConnection con = new SqlConnection(conStr);
    SqlCommand com = new SqlCommand("GET_PRODUCTS_SP", con);
    com.Parameters.AddWithValue("@id", yourIdValue);
    com.Parameters.AddWithValue("@name", yourNameValue);
    com.Parameters.AddWithValue("@description", yourDescriptionValue);
    com.CommandType = CommandType.StoredProcedure;
    SqlDataAdapter da = new SqlDataAdapter(com);
    try
    {
        con.Open();
        da.Fill(dt);
    }
    catch (Exception)
    {
        throw;
    }
    finally
    {
        if (con.State == ConnectionState.Open)
        con.Close();
    }
    GridView1.DataSource = dt;
    GridView1.DataBind();
