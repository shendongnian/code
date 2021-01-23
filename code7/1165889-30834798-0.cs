    var dataInput = db.VisitedCities
                    .GroupBy(c => c.PersonWhoVisitedNationalityId)
                    .Join(db.Countries, s => s.Key, c => c.CountryId, (s, c) => new { s, c })
                    .OrderBy(c => c.c.Name)
                    .Select(cp => new
                    {
                        Country = cp.c,
                        VisitationsByCity = cp.s
                        .GroupBy(x => x.CityId)
                        .Join(db.Cities, s => s.Key, c => c.CityId, (s, c) => new { s, c })
                        .Select(c => new
                        {
                            City = c.c,
                            NumberOfVisits = c.s.Count()
                        })
                    }).ToList();
