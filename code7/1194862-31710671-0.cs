        List<int> userData = new List<int>();
        MySqlConnection bag = new MySqlConnection(connstring);
        MySqlCommand cmd = new MySqlCommand("Select readerid From readers",bag);
        bag.Open();
        MySqlDataReader oku = cmd.ExecuteReader();
        while (oku.Read())
        {
        int current = Convert.ToInt32(oku.GetString(1));
        userData.Add(current);
        listBox1.Items.Add(current);
        }
