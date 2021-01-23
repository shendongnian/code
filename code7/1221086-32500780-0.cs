     private void GetResults()
            {
                //Establishing the MySQL Connection
                 MySqlConnection conn = new MySqlConnection("Database=potentiality_live;Data Source=eu;User Id=ptly;Password=phat40");
     
                string query;
                MySqlCommand SqlCommand;
                MySqlDataReader reader;
     
                MySqlDataAdapter adapter = new MySqlDataAdapter();
    //Open the connection to db
                conn.Open();
     
    //Generating the query to fetch the contact details
                query = "SELECT id,date_time,link FROM'sdfsdfsdf'";
     
     SqlCommand = new MySqlCommand(query, conn);
                adapter.SelectCommand = new MySqlCommand(query, conn);
    //execute the query
                reader = SqlCommand.ExecuteReader();
    //Assign the results 
                GridView1.DataSource = reader;
     
    //Bind the data
                GridView1.DataBind();
     
    }
