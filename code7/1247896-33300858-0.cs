    using(var con = new SqlConnection(conString))
    using(var cmd = con.CreateCommand())
    {
       cmd.CommandText = "Insert into tblFees(Salutation,Name) VALUES (@d1,@d2)";
       cmd.Parameters.Add("@d1", SqlDbType.NVarChar).Value = cmbSalutation.Text;
       cmd.Parameters.Add("@d2", SqlDbType.NVarChar).Value = tbName.Text;
    
       con.Open();
       cmd.ExecuteNonQuery();
    }
