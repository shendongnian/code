    var query = dbo.Records.AsQueryable()
              .Select(x => new
              {
                  Id = x.Id,
                  Care = new
                  {
                      x.StartDate,
                      x.ForwardedBy,
                  },
                  Prescriptions = x.Prescriptions.ToList().Select(p => new
                  {
                      p.Medicament,
                      p.IntervalUse.GetDisplayName()
                  }),
              }).OrderByDescending(x => x.Id);
