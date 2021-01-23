    var q1 = (from sp in _db.Species
                    from p in _db.Pets
                    from b in _db.Bookings.Where(x => x.ExpectedArrivalTime.Year == year &&
                        x.ExpectedArrivalTime.Month == month)
                    where p.SpeciesId == sp.Id && b.PetId == p.Id && b.PetId == p.Id
                    select new {sp.SpeicesName, Sum = b.Services.Sum(i => i.Price)})
                    .GroupBy(x => x.SpeicesName).Select(g=>new {SpeicesName=g.Key,Sum=g.Sum(e=>e.Sum)}).ToList();
