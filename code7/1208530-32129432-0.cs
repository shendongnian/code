    public IEnumerable<City> GetByCountriesId(int id)
    {
        return from country in this.Context.Countries
               where country.Id == id
               from state in country.States
               from c in this.Context.Cities.Include(c => c.States.Select(s => s.Countries))
               where c.States.Any(s => s == state)
               select c;
    }
