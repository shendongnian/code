    public IEnumerable<Daten> Select()
    {
        string query = "SELECT * FROM tableinfo";
    
        //Create a list to store the result
        List<Daten>list = new List<Daten>();
    	
        //Open connection
        if (this.OpenConnection() == true)
        {
            //Create Command
            MySqlCommand cmd = new MySqlCommand(query, connection);
            //Create a data reader and Execute the command
            MySqlDataReader dataReader = cmd.ExecuteReader();
            
            //Read the data and store them in the list
            while (dataReader.Read())
            {
    			var id = dataReader["id"];
    			var name = dataReader["name"];
    			var age = dataReader["age"];
    			
    			var daten = new Daten { Id = id, Age = age, Name = name };
    			list.Add(daten)
            }
    
            //close Data Reader
            dataReader.Close();
    
            //close Connection
            this.CloseConnection();
    
            //return list to be displayed
            return list;
        }
        else
        {
            return list;
        }
    }
