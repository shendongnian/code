    public void Insert()
    {
        using (var mform = new Form1())
        {
            // Ensure that the user entered values...
            if (mform.ShowDialog() == DialogResult.Ok)
            {
                string query = "INSERT INTO parts (item_id, description, brand, model, color, quantity) VALUES('0', '"
                   + mform.Description.Text
                   + "','" + mform.Brand.Text
                   + "','" + mform.Model.Text
                   + "','" + mform.Color.Text
                   + "','" + mform.Quantity.Text + "')";
                if (this.OpenConnection() == true)
                {
                   var cmd = new MySqlCommand(query, connection);
                   cmd.ExecuteNonQuery();
                   this.CloseConnection();
                }
            }
        }
    }
