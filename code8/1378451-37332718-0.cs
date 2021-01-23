    var whtRatesDTOList = from whtRatesItem in aqrOperationsDbCtx.WHTRatesMasterDbSet.ToList()
                         join country in secMasterDbCtx.CountryCodesDbSet.ToList() on whtRatesItem.Country equals country.Iso3CountryCode
                         select new WHTRatesMasterDTO()
                         {
                             CountryName = whtRatesItem.Country,
                             CountryIsoCode = country.Iso3CountryCode,
                             };
