    public IList<HotelsDetailsDto> GetHotels()
    {
        return db.Hotels.Select(p => new HotelsDetailsDto
        {
            Id = p.Id,
    
            //removed other lines for brevity
    
            LocationName = p.Location.Name,
            LocationImage = p.Location.Image
      }).ToList();
    }
