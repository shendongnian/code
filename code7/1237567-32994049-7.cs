    private void getListBtn_Click(object sender, RoutedEventArg e)
    {
        Sqlconnect Con = new Sqlconnect();//instantiate a new object 'Con' from the class Sqlconnect.cs
        Con.conOpen();//method to open the connection.
     
        //you should test if the connection is open or not
        if(Con!= null && Con.State == ConnectionState.Open)//youtest if the object exist and if his state is open
        {
            //make your query
            SqlDataAdapter sda = new SqlDataAdapter("your query", Con);
            //etc
            
            Con.conClose();//close your connection
        }
        else
        {
            //the connection failed so do some stuff, messagebox...as you want
            return;//close the event
        }
    
    }
