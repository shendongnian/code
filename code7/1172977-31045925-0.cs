     // Server side: 
    protected override Task OnConnected(IRequest request,  
                                     string connectionId) 
    { 
        var db = new allEntities();
        var db2 =new allEntities2();
        var data1 = db.Tables.Where(e=>e.LastUpdate<=datetime.now.AddDays(-1));
        var data2=db2.Tables.Where(e=>e.Something==someRef);
        var data=combine(data1,data2);//combine logic goes here
        return Connection.Send(connectionId, data.ToList()); 
    }
