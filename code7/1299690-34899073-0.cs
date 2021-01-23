    string sql = "UPDATE APPOINTMENTS Set [CustomerID]=@id,[DateTime]=@dateTime,[Time]=@time WHERE [CustomerID]=@customerid";
    using (SqlConnection cn = new SqlConnection("Your connection string here"))
       {
          using (SqlCommand cmd = new SqlCommand(sql, cn))
              {
                 cmd.Parameters.Add("@id", SqlDbType.VarChar, 50).Value = "Some value Here";
                 cmd.Parameters.Add("@dateTime", SqlDbType.DateTime).Value = "Some value Here";
                 cmd.Parameters.Add("@time", SqlDbType.Time).Value = "Some value Here";
                 cmd.Parameters.Add("@customerid", SqlDbType.VarChar, 50).Value = "Some value Here";
                  //execute command here
              }
       }
