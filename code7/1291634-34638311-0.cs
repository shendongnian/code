    SqlConnection con = new SqlConnection(connectionString);
    con.Open();
    try
    {
        //some code that can throw an exception here....
    }
    catch (Exception)
    {
        //is there any possibility of this error close the connection? no
    } 
    finally 
    {
        //call close here - finally block will always execute
        con.Close();
    }
