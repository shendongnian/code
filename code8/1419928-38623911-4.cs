    var query = dbo.Records.Include(x => x.Prescriptions).OrderByDescending(x => x.Id).AsEnumerable()
                .Select(x => new
                {
                    Id = x.Id,
                    Care = new
                    {
                        x.StartDate,
                        x.ForwardedBy,
                    },
                    Prescriptions = x.Prescriptions.Select(p => new
                    {
                        p.Medicament,
                        p.IntervalUse.GetDisplayName()
                    }),
                });
