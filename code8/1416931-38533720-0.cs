    private void button2_Click(object sender, EventArgs e)
    {
        try
        {
            using (var Conn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=BoilerSvc_be.mdb"))
            {
                var command = new OleDbCommand("INSERT INTO Contacts (" + 
                                     "Title,   Initial,  Surname,[Address 1],[Address 2],[Address 3],[Post Town],[Post Code],Telephone,Archived)" +
                            " VALUES (    ?,         ?,        ?,          ?,          ?,          ?,          ?,          ?,        ?,       0)", Conn);
                Control[] controls = { Titl, FirstName, LastName,   Address1,   Address2,   Address3,   TownCity,   Postcode,   PhnNum };
                foreach (var control in controls)
                    command.Parameters.AddWithValue("@" + control.Name,
                        string.IsNullOrEmpty(control.Text) ? DBNull.Value : control.Text as object);
                Conn.Open();
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Customer Added");
                    foreach (var control in controls)
                        control.Text = "";
                }
                else
                    MessageBox.Show("Customer was not Added");
            } // Conn is closed and disposed at the end of the using block
        }
        catch (Exception ex) { 
            MessageBox.Show("Exception : " + ex.Message);
        }
    }
