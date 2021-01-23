    using(var conn = new MySqlConnection(mycon))
    using(var cmd = conn.CreateCommand())
    {
        cmd.CommandText = "SELECT * FROM instructor WHERE instructorType = @type";
        cmd.Parameters.Add("@type", labelClass.Text);
        
        conn.Open();
        using(var myReader = cmd.ExecuteReader())
        {
            while (myReader.Read())
            {
                 cmbInstructor.Items.Add(myReader["instructorLN"].ToString());
            }
        }
    }
