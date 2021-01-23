    // Source of the DynamicParameters
    var args = new Dictionary<string,string>();
    args.Add("@emailPromotion", "1");
    // additional args goes here
    
    // An example of how you build a DynamicParameters
    var dbArgs = new DynamicParameters();
    foreach (var pair in args) dbArgs.Add(pair.Key, pair.Value);
    
    // The query - using SQL Server (AdventureWorks)
    var sql = "select * from Person.Contact WHERE EmailPromotion = @EmailPromotion";
    
    // The Dapper call (this works as expected)
    var items = the_connection.Query<dynamic>(sql, dbArgs);    
    
