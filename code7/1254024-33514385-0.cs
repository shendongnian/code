    If(!Page.IsPostBack)
    {
       string query_regNo = @"SELECT spare_part FROM spare_parts";
       cb_description.Items.Clear();
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query_regNo, conn);
                MySqlDataReader DR = cmd.ExecuteReader();
                while (DR.Read())
                {
                    cb_description.Items.Add(new ListItem(DR[0].ToString()));
                }
            }
    }
