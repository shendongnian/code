    private void button2_Click(object sender, EventArgs e)
    {
        using(var con = new SqlCeConnection(conString))
        using(var command = con.CreateCommand())
        {
           command.CommandText = "DELETE FROM pricedata WHERE Item = @item";
           command.Parameters.Clear();
           command.Parameters.AddWithValue("@item", comboBox1.SelectedItem.ToString());
           con.Open();
           command.ExecuteNonQuery();
        }                 
    }
