    //return full data
    public UserFull GetUser(Guid userId)
    {
        using (var c = ConnectionToDataBase())
        {
            var user = c.Users
                  .Where(u => u.Id==userId)
                  .Select(u => new UserFull
                  {
                      Id = u.Id,
                      Name = u.Name,
                      Company = u.Company //force execution
                  }).FirstOrDefault();
            return user;
        }
    }
    //return partial data
    public dynamic GetUser(Guid userId)
    {
        using (var c = ConnectionToDataBase())
        {
            var user = c.Users
                  .Where(u => u.Id==userId)
                  .Select(u => new 
                  {
                      Id = u.Id,
                      Name = u.Name,
                  }).FirstOrDefault();
            return user;
        }
    }
    [HttpGet, Route("api/users/{userId:guid}")]
    public IHttpActionResult User(Guid userId)
    {
       try
       {
           var res = GetUser(Guid userId);
           return Ok(res);
       }
       catch
       {
            return InternalServerError();
       }
    }
