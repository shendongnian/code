    public IQueryable<State> GetAllStateByCountry(int Id)
    {
        return DbSet.Where(dto => dto.CountryId == Id)
            .Include(dto => dto.Country);
    }
