    public List<Data> FetchUserDetails()
        {
            using (var c = ManageEntity())
                 {
                     return c.AspNetUsers.Select(m => new Data{
                                        UserName= m.UserName,
                                        LockoutEnabled=m.LockoutEnabled,
                                        AccessFailedCount=m.AccessFailedCount
                                       }).ToList()
                 }
            
        }
