    from e in _context.LearnResults
     join c in _context.Country on e.CountryId equals c.CountryId
     where c.DomainId.Equals("xx")
     group e by e.Country.Name into newCountry
     let Approved = newCountry.Sum(e => e.Approved)
     let Total = newCountry.Sum(e => e.Total)
     select new LearnResults() { CountryName = newCountry.Key, Approved= Approved, Total=Total };
