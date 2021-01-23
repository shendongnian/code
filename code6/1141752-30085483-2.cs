    public static Auto findAuto(int kfznr)
    {
        Auto retAuto = new Auto();
        try
        {
            myOleDbConnection.Open();
            string query = "SELECT * FROM Auto WHERE Auto.KFZNR = " + kfznr; 
            OleDbCommand select = new OleDbCommand();
            select.Connection = myOleDbConnection;
            select.CommandText = query;
            OleDbDataReader reader = select.ExecuteReader();
            while (reader.Read())
            {
                Auto at = new Auto(Convert.ToInt32(reader["col1"]), Convert.ToString(reader["col2"]), Convert.ToString(reader["col3"]));
                retAuto = at;
            }
        }
        catch (OleDbException e)
        {
            Console.WriteLine(e.ToString());
        }
        return retAuto;
    }
