    for(int i=0;i<300;i++)
    {
       Command1 = new OleDbCommand("SELECT a FROM Table1 WHERE ID = "+i, Connection);
       try{
           Connection.Open();
           var1= (int)Command1.ExecuteScalar();
       }catch(Exception e)
       {
            //your logic here
       }
    }
