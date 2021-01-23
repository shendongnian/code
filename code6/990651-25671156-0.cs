     IEnumerable<Entities.InformationRequestTransactionGroupLink> irTransactionGroupLinksEntities = 
    (from itc in
    this.adjustmentContext.InformationRequestTransactionCodes
    join itg in this.adjustmentContext.InformationRequestTransactionGroups
    on itc.InformationRequestTransactionGroup equals itg.Group
    where itc.InformationRequestType == informationRequestType
    select new
    {
     sInformationRequestTransactionGroupType = itg.Group.Trim(),
     sCountryCode = itc.CountryCode,
     sDescription = itg.Description,
     sAppliesToAllCountries = itc.CountryCode.Trim().Equals("XX") ? true : false}).AsEnumerable()
    .Select(irtgLink => new Entities.InformationRequestTransactionGroupLink
    {
     InformationRequestTransactionGroupType = irtgLink.sInformationRequestTransactionGroupType,
     CountryCode = irtgLink.sCountryCode,
     Description = irtgLink.sDescription,
     AppliesToAllCountries = irtgLink.sCountryCode.Trim().Equals("XX") ? true : false
    });
