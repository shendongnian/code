    private void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            string sqlText = "insert into OrderForm([Size]) values (?)";
            using(OleDbConnection connection = new OleDbConnection(.....))
            using(OleDbCommand command = new OleDbCommand(sqlText, connection))
            {
                connection.Open();
                command.Parameters.Add("@p1", OleDbType.VarWChar).Value = sizeBox.Text;
                int rowsAdded = command.ExecuteNonQuery();
                if(rowsAdded > 0) 
                    MessageBox.Show("Order Inserted into Database");
                else
                    MessageBox.Show("No Order added to the Database");
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error " + ex.Message);
        }
    }
