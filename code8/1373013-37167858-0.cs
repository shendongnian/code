    Connection con = new Connection(conString);
    try 
    {
       con.Open();
       Command cmd = con.CreateCommand();
       // use command 
    }
    catch(Exception Ex)
    {
    }
    finally 
    {
       con.Close();
    }
