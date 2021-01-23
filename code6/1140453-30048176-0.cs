    private void txt_order_Click(object sender, EventArgs e)
    {
        Double PT = new Double();
        connection.Open();
        OleDbCommand command = new OleDbCommand();
        command.Connection = connection;
        command.CommandText = "insert into Comenzi (Produs,Cantitate) values('"+txt_Produs.Text+"','"+txt_Cantitate.Text+"',)" ; //+ sa adaug useru care e logat din form 1
        command.ExecuteNonQuery();
        connection.Close();
    }
