            [EnableQuery]
            public IQueryable<User> GetUsers()
            {
                var db = new Database();
                return db.Users;
            }
