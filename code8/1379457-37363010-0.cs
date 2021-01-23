     using(SqlConnection sqlconn = new SqlConnection(     
    ConfigurationManager.ConnectionStrings["defaultconnection"].ConnectionString))
     {
        sqlconn.Open();
       using(SqlCommand sqlcommand  = new SqlCommand("Select field1 FROM  
       Table",sqlconn))
       {
         //code here
       }
    }
