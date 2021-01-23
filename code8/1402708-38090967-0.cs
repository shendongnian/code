    public List<Tuple<string,string>> getTrafficLevel()
    {
        string query = "select * from traffictimeinfo where startTime<time(now()) and endTime>time(now());";
        List<Tuple<string,string>> list = new List<Tuple<string,string>>();
        if (this.openConnection() == true)
        {
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                list.Add(new Tuple<string,string>(dataReader["timeslotid"] + "", dataReader["timeslotname"] + ""));
            }
            dataReader.Close();
            this.closeConnection();
            return list;
        }
        else
        {
            return list;
        }
    }
    
