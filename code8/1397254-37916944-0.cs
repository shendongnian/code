    private void BindGrid()
    {
        string conString = @"Data Source=localhost;port=3306;Initial Catalog=TopShineDB;User Id=root;password=0159";
        using (MySqlConnection con = new MySqlConnection(conString))
        {
            using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM Table1", con))
            {
                cmd.CommandType = CommandType.Text;
                using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                {
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                }
            }
        }
    }
