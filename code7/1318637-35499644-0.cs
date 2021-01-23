    using(var connection = new OleDbConnection())
    using(var cmd = con.CreateCommand())
    {
       cmd.CommandText = @"Update Accounts set password = @newpass  
                           where Username = @user and Password = @pass";
       cmd.Parameters.Add("@newpass", OleDbType.VarWChar).Value = txtNew.Text;
       cmd.Parameters.Add("@user", OleDbType.VarWChar).Value = txtUse.Text;
       cmd.Parameters.Add("@pass", OleDbType.VarWChar).Value = txtPas.Text;
       con.Open();
       cmd.ExecuteNonQuery();
    }
