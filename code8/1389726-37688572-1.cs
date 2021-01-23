            IEnumerable<RenewalModel> result =
                (from g in (
                    from r in renewalList
                    join c in cityList on r.CityID equals c.CityID
                    select new RenewalModel
                    {
                        CityID = grpCity.Key,
                        City = (from g in grpCity where g.CityID == grpCity.Key select g.City).First().Trim(),
                        PotentialRenewalCount = (from g in grpCity where g.CityID == grpCity.Key select g.PotentialRenewalCount).Sum(),
                        PotentialRenewalSQRT = (from g in grpCity where g.CityID == grpCity.Key select g.PotentialRenewalSQRT).Sum(),
                        RENEWALCOUNT = (from g in grpCity where g.CityID == grpCity.Key select g.RENEWALCOUNT).Sum(),
                        RENEWALSQRT = (from g in grpCity where g.CityID == grpCity.Key select g.RENEWALSQRT).Sum()
                    })
                group g by g.CityID into grpCity
                select new RenewalModel
                {
                    desiredCalucation = (g.PotentialRenewalCount / g.PotentialRenewalCount) * 100,
                    CityID = g.CityID,
                    City = g.City.Trim(),
                    PotentialRenewalCount = g.PotentialRenewalCount.Sum(),
                    PotentialRenewalSQRT = g.PotentialRenewalSQRT.Sum(),
                    RENEWALCOUNT = g.RENEWALCOUNT.Sum(),
                    RENEWALSQRT = g.RENEWALSQRT.Sum()
                });
