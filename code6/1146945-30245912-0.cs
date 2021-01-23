    var applicationSubCodes = (from CustomerDemographic customerDemographic 
                     in customerData.Demographics
                   where (customerDemographic.UserD2==DateTime.MinValue)
                      && communities.Contains(x.DemographicCodeString)
                   select new Models.MemberOnlineCommunityPreferences()
                   {
                       DemographicCode = customerDemographic.DemographicCodeString,
                       DemographicSubCode = customerDemographic.DemographicSubcodeString,
                   })
            .OrderBy(x=>x.DemographicCode)
            .Select(x => TIMSS.API.CachedApplicationData.ApplicationDataCache.get_ApplicationSubCode("CUS", "DEMOGRAPHIC", x.DemographicCodeg, x.DemographicSubCode))
            .Where(x => x.WebEnabled == "Y" && x.Active == "Y")
            .ToList();
