    public class LocationDTO
    {
        public string Name { get; set; }
        public string PostCode { get; set; }
        // ...
    }
    // ...
    
    return locations.Select(l => new LocationDTO
    {
        Name = l.suburb.Name,
        PostCode = l.suburb.PostCode,
        // ...
    }).ToList()
