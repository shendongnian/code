    var data = HttpRuntime.Cache["ProjectId"] as Dictionary<string, DateTime>;
    if(data==null)
        data=new Dictionary<string, DateTime>();
    data.Add("Scott",DateTime.Now);
    data.Add("Shyju", DateTime.Now);
    data.Add("Kevin", DateTime.Now);
    HttpRuntime.Cache["ProjectId"] = data;
