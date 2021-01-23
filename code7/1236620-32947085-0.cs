    public DataTable GetAlltheatredet()//I got error here//
    {
        DataTable myalltheat = GetAllmytheatdet();
        foreach (DataRow drow1 in myalltheat.Rows)
        {
            usermsterid = drow1["UserMasterId"].ToString();
            if (usrmid == usermsterid)
            {
                flag = 1;
                break;
            }
            if (flag == 1)
            {
                try
                {
                    string connString = "Server=localhost;database=Mytable;uid=root;";
                    string query = "SELECT * FROM `Mytable`.`Mydata`";
                    MySqlDataAdapter ma = new MySqlDataAdapter(query, connString);
                    DataSet DS = new DataSet();
                    ma.Fill(DS);
                    return DS.Tables[0];
                }
                catch (MySqlException e)
                {
                    throw new Exception(e.Message);
                }
            }
            else {
                throw new Exception("Flag isn't 1 and I don't know what to do");
            }
        }
    }
