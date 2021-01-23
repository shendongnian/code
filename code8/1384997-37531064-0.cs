    [HttpGet]
    public HttpResponseMessage GetTest(string name)
    {
        using (MyEntities bm = new MyEntities())
        {
            var usr = bm.Users.Where(u => u.Name == name ).ToList();
    
            if (usr.Count() > 0)
                return Request.CreateResponse(HttpStatusCode.OK, new
                {
                    Success = true
                        ,
                    Message = "Total users: " + usr.Count()
                        ,
                    Data = usr
                });
    
            return Request.CreateResponse(HttpStatusCode.NotFound, new { Success = false, Message = "No users found..." });
        }
    }
