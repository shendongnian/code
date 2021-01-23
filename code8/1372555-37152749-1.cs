    using(var northwindConnection = new OleDbConnection())
    {
        //Set your connection info
        using(var northwindCommand = northwindConnection.CreateCommand())
        {
            //Set your command info
            try
            {
                // Open your connection and any other things 
                // needed before executing your reader
                using(var reader = northwindCommand.ExecuteReader()){
                    //Do what you need with your reader
                }
            }
            catch(Exception mistake)
            {
                MessageBox.Show(mistake.ToString());
            }
        }
    }
