    public List<Person> GetEmailAddresses()
    {
        using (yourEntities awlt = new yourEntities())
        {
            var query = awlt.People.Include("EmailAddresses")
                    .Where(p => p.LastName.Equals(lastName));
            return query.ToList();
        }
    }
