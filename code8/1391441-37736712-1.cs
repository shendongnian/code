    string cmdText = @"UPDATE Sales SET Printer = @printer,
                       Ink = @Ink, Paper = @Paper 
                       WHERE EmID = @id";
    using(OleDbConnection con = new OleDbConnection(...))
    using(OleDbCommand cmd = new OleDbCommand(cmdText, con))
    {
        con.Open();
        cmd.Parameters.Add("@printer", OleDbType.VarWChar).Value = txtPrinter.Text;
        cmd.Parameters.Add("@ink", OleDbType.VarWChar).Value = txtInk.Text;
        cmd.Parameters.Add("@paper", OleDbType.VarWChar).Value = txtPaper.Text;
        cmd.Parameters.Add("@id", OleDbType.VarWChar).Value = txtEmpID.Text;
        cmd.ExecuteNonQuery();
    }
