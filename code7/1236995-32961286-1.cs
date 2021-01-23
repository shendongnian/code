    public IHttpActionResult TimeDataByUserName(string userName)
    {
      List<Model> res = new List<Model>();
      IQueryable<Overalldata> Serverdata = db.Overalldatas.Where(x => x.User.Equals(userName));
      var groupServerData = Serverdata.GroupBy(x => new {x.EventDate, x.Server}).ToList();
      res.AddRange(groupServerData.Select(item => new Model()
      {
        Count = item.Count(),
        Date = item.Key.EventDate.ToString("yyyy-MM-dd HH:mm:ss"),
        Name = item.Key.Server
      }));
    
      return Ok(res);
    }
    
    public IHttpActionResult TimeDataByServerName(string serverName)
    {
      List<Model> res = new List<Model>();
      IQueryable<Overalldata> UserData = db.Overalldatas.Where(x => x.Server.Equals(serverName));
      var groupedUserData = UserData.GroupBy(x => new {x.EventDate, x.User}).ToList();
      res.AddRange(groupedUserData.Select(item => new Model()
      {
        Count = item.Count(),
        Date = item.Key.EventDate.ToString("yyyy-MM-dd HH:mm:ss"),
        Name = item.Key.User
      }));
    }
