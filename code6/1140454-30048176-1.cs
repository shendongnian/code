    private void txt_order_Click(object sender, EventArgs e)
    {
        Double PT = new Double();
        connection.Open();
        OleDbCommand command = new OleDbCommand();
        command.Connection = connection;
        command.CommandText = "insert into Comenzi (Produs,Cantitate) values(@product, @cantitate)" ; //+ sa adaug useru care e logat din form 1
        command.Parameters.AddWithValue("@product", txt_Produs.Text);
        command.Parameters.AddWithValue("@cantitate", Convert.ToInt32(txt_Cantitate.Text);
        command.ExecuteNonQuery();
        connection.Close();
    }
