    string cmdText = "DELETE from Ledger Where AccountNumber = @num";
    using(OleDbConnection con = new OleDbConnection(......))
    using(OleDbCommand cmd = new OleDbCommand(cmdText, con))
    {
        con.Open();
        cmd.Parameters.Add("@num", OleDbType.Integer).Value =   
                 Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
        cmd.ExecuteNonQuery();
        dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
        MessageBox.Show("Row Deleted");
        Load_data();
    }
