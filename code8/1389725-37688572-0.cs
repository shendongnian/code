            IEnumerable<RenewalModel> result =
                (from r in renewalLists
                group r by r.CityID into grpCity
                select new RenewalModel
                {
                    CityID = grpCity.Key,
                    City = (from g in grpCity where g.CityID == grpCity.Key select g.City).First().Trim(),
                    PotentialRenewalCount = (from g in grpCity where g.CityID == grpCity.Key select g.PotentialRenewalCount).Sum(),
                    PotentialRenewalSQRT = (from g in grpCity where g.CityID == grpCity.Key select g.PotentialRenewalSQRT).Sum(),
                    RENEWALCOUNT = (from g in grpCity where g.CityID == grpCity.Key select g.RENEWALCOUNT).Sum(),
                    RENEWALSQRT = (from g in grpCity where g.CityID == grpCity.Key select g.RENEWALSQRT).Sum()
                }).select(r => new RenewalModel
                {
                    desiredCalucation = (r.PotentialRenewalCount / r.PotentialRenewalCount) * 100,
                    CityID = r.CityID,
                    City = r.City,
                    PotentialRenewalCount = r.PotentialRenewalCount,
                    PotentialRenewalSQRT = r.PotentialRenewalSQRT,
                    RENEWALCOUNT = r.RENEWALCOUNT,
                    RENEWALSQRT = r.RENEWALSQRT
                });
