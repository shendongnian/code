    public class Person
    {
       public string Firstname { get; set; }
       public string Lastname { get; set; }
       /* ... */
    }
    public IList<Person> GetData(long Id)
    {   
        var query = from u in dataContext.tblUsers
                    join p in dataContext.tblUsersProfiles on u.ProfileId equals p.Id
                    join c in dataContext.tblComments on u.Id equals c.Commentedby
                    where c.Id == Id
                    select new Person { u.Firstname, u.Lastname /* ... */ };
            return query.ToList();
    }
