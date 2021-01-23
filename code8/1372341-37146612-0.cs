    int companyId=0;
    using (SqlConnection conn = new SqlConnection(cs))
    {
         conn.Open();
         SqlCommand scmd = conn.CreateCommand();
         scmd.CommandText = "SELECT * FROM dbo.Person WHERE Id=@PId";
         scmd.Parameters.AddWithValue("@PId", lstContactList.SelectedIndex + 1);
         SqlDataReader dr = scmd.ExecuteReader();
         if(dr.Read())
         {
              txtbFirstName.Text = dr["FirstName"].ToString();
              txtbLastName.Text = dr["LAstName"].ToString();
              companyId=int.Parse(dr["CompanyId"].ToString());
         }
         conn.Close();
    }
