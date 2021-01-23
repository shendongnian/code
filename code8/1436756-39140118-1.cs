    public IEnumerable<EventDto> IncludeAddress(DbContext dbContext)
    {
        return dbContext.Event.Select(t => new
        {
            // select out your other properties here
            Address = new
            {
                AddressLine1 = t.Address.AddressLine1,
                CityName = t.Address.AddressCityName
            },
        }).ToList().Select(x => new EventDto { Address = Address });
        // put what ever mapping logic you have up there, whether you use AutoMapper or hand map it doesn't matter.
    }
