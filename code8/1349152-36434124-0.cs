    public void ReadFromDatabase()
    {
    	int idToFind;
    	
        //check that imageidTxt.Text is an integer
    	if	(Int32.TryParse(imageidTxt.Text, out idToFind))
    	{
    		//we have an integer, so look at the database
            string sql = "SELECT * FROM Table WHERE ID=" + idToFind;
            //connect to/read from DB
    	}
        else
        {
            //fail spectacularly
        }
    }
