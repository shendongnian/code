    public void loadXML(string path, string table, string identify)
        {
        var con = new Connection(ConnectionString)
            string query = "LOAD XML LOCAL INFILE ";
            query += "'"+path+"'";
            query += " INTO TABLE " + table;
            query += " Rows Identified By '<" + identify + ">';";
            System.Diagnostics.Debug.Print(query);
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query,con );
    
                //Execute command
                cmd.ExecuteNonQuery();
    
                //close connection
                this.CloseConnection();
            }
    
        } 
