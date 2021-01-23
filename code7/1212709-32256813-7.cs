    var client = new MongoClient(connectionString);  
    var server = client.GetServer();  
    var database = server.GetDatabase("ComputerDB");  
    var computerCollection= database.GetCollection<Computer>("Computers");
    foreach(var computer in computers)
    {  
        computerCollection.Insert(computer);
    } 
 
