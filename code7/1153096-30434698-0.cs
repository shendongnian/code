    public class LocationDTO
    {
        public string Name { get; set; }
        public string PostCode { get; set; }
        // ...
    }
    // ...
    
    return locations.Select(l => new LocationDTO
    {
        Name = suburb.Name,
        PostCode = suburb.PostCode,
        // ...
    }).ToList()
