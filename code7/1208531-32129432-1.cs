    public IEnumerable<City> GetByCountryId(int id)
    {
        return from c in this.Context.Cities
                         .Include(c => c.States.Select(s => s.Countries))
               where c.States.Any(s => s.Countries.Any(c => c.Id == id))
               select c;
    }
