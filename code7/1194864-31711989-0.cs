    var userData = new List<int>();
    using (var bag = new MySqlConnection(connstring))
    using (var cmd = new MySqlCommand("Select readerid From readers",bag))
    {
        bag.Open();
        using (MySqlDataReader oku = cmd.ExecuteReader())
        {
            while (oku.Read())
            {
                userData.Add(oku[0]);
                //userData.Add(oku["readerid"]); //would also work
            }
        }
    }
