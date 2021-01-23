    public List<Person> GetEmailAddresses()
    {
        using (yourEntities awlt = new yourEntities())
        {
            var query = awlt.People
                    .Where(p => p.LastName.Equals(lastName));
            return query.ToList();
        }
    }
