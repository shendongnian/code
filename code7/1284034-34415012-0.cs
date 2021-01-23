    var size = new List<t>() ;
    
    using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["batch"].ConnectionString))
    {
    
     size = FileBusinessLogic.LoadBatchAvgFileSizes(connection);  
    
       }
  
    
