    // class level var or whatnot:
    string connString = @"server=theHostName;userid=dbuser123;password=OpenSesame7;database=my_db_name";
    
    public void connect()
    {
        try
        {
            conn = new MySqlConnection(connString); // read above comments for (conn)
            conn.Open();
        }
        catch (MySqlException ex)
        {
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            string s="MySqlException: "+ex.ToString();
            MessageBox.Show(s,"Error",buttons);
        }
        finally
        {
            if (conn != null)
            {
                //conn.Close();
            }
        }
    }
