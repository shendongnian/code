    using (SqlConnection conn = new SqlConnection(NorthwindConnectionString))
    {
        string query = "SELECT * FROM Products WHERE ProductID = @Id";
        SqlCommand cmd = new SqlCommand(query, conn);
        cmd.Parameters.AddWithValue("@Id", Request.QueryString["Id"]);
        conn.Open();
        using (SqlDataReader rdr = cmd.ExecuteReader())
        {
            DetailsView1.DataSource = rdr;
            DetailsView1.DataBind();
        }
    }
