    using (SqlConnection connection = new SqlConnection("Your Connection String"))
        {
            string sqlQuery = "Your Query";
            using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    connection.Open();
                    sda.SelectCommand = cmd;
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
            }
        }
