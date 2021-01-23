    using(var connection = new OleDbConnection(conString))
    using(var dbcmd = connection.CreateCommand())
    {
        dbcmd.CommandText = "insert into ConveyanceBill1 (empname, from) values(?, ?)";
        dbcmd.Parameters.Add("?", OleDbType.VarWChar).Value = txtEmployee.Text;
        dbcmd.Parameters.Add("?", OleDbType.VarWChar).Value = txtFrom.Text;
       
        connection.Open();
        int effectedRows = dbcmd.ExecuteNonQuery();
        if(effectedRows > 0)
        {
           MessageBox.Show("Sucessfully Added!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }   
    }
