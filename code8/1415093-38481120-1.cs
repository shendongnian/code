     public IList<HotelsDetailsDto> GetHotels()
            {
                return db.Hotels.Include(x => x.Himage).Include(x => x.Location)
    .Select(p => new HotelsDetailsDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    // Other fields
                    HimageId = p.Himage.Id,          //HimageId is a foreign key
                    LocationId =p.Location.Id,      //LocationId is a foreign key               
                  }).ToList();
            
