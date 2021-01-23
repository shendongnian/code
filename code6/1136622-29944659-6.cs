    public Users
    {
        public string UserName { get; set; }
        public bool EmailConfirmed { get; set; }
    }
    var sqlQuery = "SELECT Users.UserName, Users.EmailConfirmed FROM AspNetUsers WHERE Users.EmailConfirmed = {0}"
    var unconfirmedUsers = dbContext.Database.SqlQuery<Users>(sqlQuery, false).ToList();
