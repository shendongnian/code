    using (SqlConnection conn = new SqlConnection(cs))
    {
         conn.Open();
         SqlCommand scmd = conn.CreateCommand();
         scmd.CommandText = "SELECT * FROM dbo.Company WHERE Id=@CId";
         scmd.Parameters.AddWithValue("@CId", companyId);
         SqlDataReader dr = scmd.ExecuteReader();
         if(dr.Read())
         {
              txtbCompany.Text=int.Parse(dr["Company_Name"].ToString());
         }
         conn.Close();
    }
