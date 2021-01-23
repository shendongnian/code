    var allPersons = from p in this.ObjectContext.Person
                     join f in this.ObjectContext.FriendVisit
                     on p.IdPerson equals f.IdPerson
                     group by new { p, f }
                     select new 
                     {
                         Name = p.Name;
                         Duration = f.OrderBy(x=>x.TimeOfVisit).Last().Duration
                     };
