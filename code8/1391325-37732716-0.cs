    private void searchB_Click(object sender, EventArgs e)
    {
        con.Open();
        var query = "SELECT * FROM details WHERE ID = @id";
        using(var cmd = new SqlCommand(query, connection))
        {
             cmd.Parameters.AddWithValue("@id",idBox.Text);
             using(var reader = cmd.ExecuteReader())
             {
                   // Access your results here and do something with them
             }
        }
    }
