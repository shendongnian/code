        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string connStr = @"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\vicky\Desktop\Gym management system\Fitness_club\vicky.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
            string cmdText = "Select * FROM [plan] where plantype=@planType";
            using (SqlConnection con = new SqlConnection(connStr))
            using (SqlCommand cmd = con.CreateCommand())
            {
                con.Open();
                cmd.CommandText = cmdText;
                cmd.Parameters.AddWithValue("@planType", comboBox1.Text);
                var reader = cmd.ExecuteReader(CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    string amount = reader.GetString(1);
                    textbox5.Text = amount;
                }
            }
        }
