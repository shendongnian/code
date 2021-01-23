    private void buttonRegistreren_Click(object sender, EventArgs e)
    {
        using(OleDbConnection cn = new OleDbConnection(.....))
        using(OleDbCommand command = new OleDbCommand(@"INSERT INTO Gebruikers
                        (Username, [Password]) values(@name, @pwd)", cn))
        {
            cn.Open();
            command.Parameters.Add("@name", OleDbType.NVarWChar).Value =textBoxUserregist.Text ;
            command.Parameters.Add("@pwd", OleDbType.NVarWChar).Value = textBoxPassregist.Text;
            command.ExecuteNonQuery();
        }
    }
