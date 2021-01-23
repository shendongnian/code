    var results = from CustomerDemographic customerDemographic in customerData.Demographics
    let code = customerDemographic.DemographicCodeString
    let subcode = customerDemographic.DemographicSubcodeString
    where communities.Contains(code) && customerDemographic.UserD2==DateTime.MinValue
    let appSubCode = TIMSS.API.CachedApplicationData.ApplicationDataCache.get_ApplicationSubCode("CUS", "DEMOGRAPHIC", code, subcode)
    where appSubCode.WebEnabled =="Y" && appSubCode.Active=="Y"
    select new Models.MemberOnlineCommunityPreferences()
           {
               DemographicCode = code,
               DemographicSubCode = subcode
           };
