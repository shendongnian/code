    var result = context.Countries
        .Where
        (
            x=>
            x.Name.Contains('Sa') &&
            x.Destinations.Any(d=>d.DestinationName.Contains('sa'))
        )
        .Select
        (
            x=> new Country
            {
                Name = x.Name,
                Destinations = x.Destinations
                    .Where(d=>d.DestinationName.Contains('sa'))
                    .Select
                    (
                        d=>new Destination
                        {
                            Id = d.Id,
                            DestinationID = d.DestinationID ,
                            DestinationName = d.DestinationName ,
                            CountryID = d.CountryID ,
                            State = d.State
                        }
                    )
            }
        )
        
