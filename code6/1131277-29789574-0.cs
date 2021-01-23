    string Query = "update host set [field1] = ?, [field2] = ?";
    OleDbConnection con = new OleDbConnection(constring);
    OleDbCommand cmd = new OleDbCommand(Query, con);
    cmd.Parameters.Add("field1", OleDbType.VarWChar).Value = field1TextBox.Text;
    cmd.Parameters.Add("field2", OleDbType.VarWChar).Value = field2TextBox.Text;
    try {
        con.Open();
        cmd.ExecuteNonQuery();
        MessageBox.Show("Data Updated");
        con.Close();
    }
