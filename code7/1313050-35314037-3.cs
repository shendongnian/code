    public IList<DataClass> GetData(long Id)
    {
        var query = from u in dataContext.tblUsers
                    join p in dataContext.tblUsersProfiles on u.ProfileId equals p.Id
                    join c in dataContext.tblComments on u.Id equals c.Commentedby
                    where c.Id == Id
        select new DataClass
        {
            Firstname = u.Firstname,
            Lastname = u.Lastname,
            ProfilePicPath = p.ProfilePicPath,
            Comment = c.Comment,
            CommentDate = c.CommentDate
        };
        return query.ToList();
    }
