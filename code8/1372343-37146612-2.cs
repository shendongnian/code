    int companyId=0;
    using (SqlConnection conn = new SqlConnection(cs))
    {
         conn.Open();
         SqlCommand scmd = conn.CreateCommand();
         scmd.CommandText = "SELECT *,CompanyName FROM dbo.Person p join dbo.Company c ON p.CompanyId = c.CompanyId WHERE Id=@PId";
         scmd.Parameters.AddWithValue("@PId", lstContactList.SelectedIndex + 1);
         SqlDataReader dr = scmd.ExecuteReader();
         if(dr.Read())
         {
              txtbFirstName.Text = dr["FirstName"].ToString();
              txtbLastName.Text = dr["LAstName"].ToString();
              txtbCompany.Text=int.Parse(dr["CompanyName "].ToString());
         }
         conn.Close();
    }
