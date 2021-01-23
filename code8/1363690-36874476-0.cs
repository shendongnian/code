       using (var connection = new System.Data.SqlClient.SqlConnection(" "))
                {
                    connection.Open();
                    var tran = connection.BeginTransaction();
    
                    var cmd = new System.Data.SqlClient.SqlCommand();
                    cmd.Connection = connection;
                    cmd.Transaction = tran;
                  
                     
                    //I dont know how the sql command relates to this  
                    products.Update(dataSet, "Produktai");
                    offers.Update(dataSet, "Pasiulimai");
    
                    //commit
                    tran.Commit(); 
                }
