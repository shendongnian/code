    private void getListBtn_Click(object sender, RoutedEventArg e)
    {
        Sqlconnect con = new Sqlconnect();//instantiate a new object 'Con' from the class Sqlconnect.cs
        con.conOpen();//method to open the connection.
     
        //you should test if the connection is open or not
        if(con!= null && con.State == ConnectionState.Open)//youtest if the object exist and if his state is open
        {
            //make your query
            SqlDataAdapter sda = new SqlDataAdapter("your query", con);
            //etc
            
            con.conClose();//close your connection
        }
        else
        {
            //the connection failed so do some stuff, messagebox...as you want
            return;//close the event
        }
    
    }
