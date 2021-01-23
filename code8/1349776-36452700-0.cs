    List<RequestStatusModel> objRequestStatus = new List<RequestStatusModel>();
    var query = from r in SimCareDB.Requests
                where r.CustomerID == 31
                select (new RequestStatusModel
                {
                   //...
                });
   
    if(data != null) //Replace with additional checks, if neccessary
    {
       query = query.where(x=> ...);
    }
    if(status != null) 
    {
       query = query.where(x => ...)
    }
