    public IHttpActionResult TimeDatawithUserandServer(string name, string group)
    {
        List<Model> res = new List<Model>();
        var groupedData = group.Equals("1") ? FetchServerData(name) : FetchUserData(name);
        res.AddRange(groupedData.Select(item => new Model()
            {
                Count = item.Count(),
                Date = item.Key.EventDate.ToString("yyyy-MM-dd HH:mm:ss"),
                Name = item.Key.Server
            }));
        return Ok(res);
    }
    private GroupedDataType FetchServerData(string name)
    {
         var realName = name.Replace("-", ".");
         var UserData = db.Overalldatas.Where(x => x.Server.Equals(realName));
         return UserData.GroupBy(x => new {x.EventDate, x.User}).ToList();
    }
    private GroupedDataType FetchUserData(string name)
    {
        var Serverdata = db.Overalldatas.Where(x => x.User.Equals(name));
        return Serverdata.GroupBy(x => new {x.EventDate, x.Server}).ToList();
    }
