    //Connect to the local, default instance of SQL Server.   
    Server srv = new Server();  
    
    // Define a Database object variable by supplying the server and the 
    // database name arguments in the constructor.   
    Database db = new Database(srv, "Test_SMO_Database");  
    
    //Create the database on the instance of SQL Server.   
    db.Create();  
    
    //Reference the database and display the date when it was created.   
    db = srv.Databases["Test_SMO_Database"];  
    Console.WriteLine(db.CreateDate);  
    
