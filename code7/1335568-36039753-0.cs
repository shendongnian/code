    var packageList = (from destination in xd.Descendants("Destination")
                            select new 
                            {
                                DestinationCityCode = destination.Element("CityCode").Value,
                                DepartureCityCode = destination.Descendants("Departure")
                                    .Select(c => new 
                                    {
                                        DepartureCityCode = c.Element("CityCode").Value
                                    }).ToList(),
                                Dates = destination.Descendants("Departure").Descendants("Dates").Descendants("Date")
                                    .Select(d => new
                                   {
                                        Date = d.Value,
                                        Nights = d.Attributes("Nights").First().Value
             
            
                                   }).ToList()
                            }).ToList();
