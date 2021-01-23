    public List<tblUsers> GetData(long Id)
            {
                //var q = dataContext.tblUsers.AsEnumerable().Join(dataContext.tblUsersProfiles.AsEnumerable(),)
                var query = from u in dataContext.tblUsers
                            join p in dataContext.tblUsersProfiles on u.ProfileId equals p.Id
                            join c in dataContext.tblComments on u.Id equals c.Commentedby
                            where c.Id == Id
                            select new tblUsers { u.Firstname, u.Lastname, p.ProfilePicPath, c.Comment, c.CommentDate };
                return query.ToList();
            }
