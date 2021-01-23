    public Events GetEvent(int id)
    {
        return (from v in myEntities.Events
               where _EventID == id
               select v).SingleOrDefault();
    }
    
    public List<Fora> GetComments(int id)
    {
         return (from c in myEntities.Fora
                 orderby c.DateCreated descending
                 where c.EventID == id
                 select c).ToList();
    }
