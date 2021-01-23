          private void monthCAL_DateChanged(object sender, DateRangeEventArgs e)
    {
        string date = monthCAL.SelectionStart.Date.ToString("yyyyMMdd");
        string connetionString = null;
        MySqlConnection connection;
        MySqlCommand command;
        MySqlDataAdapter adapter = new MySqlDataAdapter();
        DataSet ds = new DataSet();
        string sql = null;
        connetionString = "datasource=localhost; database=bokning;port=3306;username=root;password=666666";
        sql = "select day, time from system where day='" + date + "'";
        connection = new MySqlConnection(connetionString);
        try
        {
            connection.Open();
            command = new MySqlCommand(sql, connection);
            adapter.SelectCommand = command;
            adapter.Fill(ds);
            adapter.Dispose();
            command.Dispose();
            connection.Close();
            MyDateT = ds.Tables[0];
            List<string> limitedList = MyDefaultList; //added line
            if (MyDateT.Rows.Count > 0)
            {
                foreach (DataRow dr in MyDateT.Rows) { 
                    for (int i = 0; i < MydefaultList.Length; i++)
                    {
                        if (MydefaultList[i].ToString().Equals(dr["time"].ToString())) {
                            limitList.Remove(MyDefaultList[i]);
                            listB1.DataSource = limitedList;
                            //listB1.Items.Remove(MydefaultList[i]); offending line
                            //listB1.DataSource = MydefaultList; offending line
                        }
                    }
            }                  
            }
            else
            {
                listB1.DataSource = MydefaultList;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    } 
