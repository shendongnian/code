    IEnumerable<ValueObjects.IR.IRTransactionGroupLink> query = 
    				from itc in adjustmentContext.InformationRequestTransactionCodes
    				join itg in adjustmentContext.InformationRequestTransactionGroups
    				on itc.InformationRequestTransactionGroup equals itg.Group 
    				where itc.InformationRequestType == informationRequestType 
    				select new
    				{
    					GroupType = itg.Group,
    					CountryCode = itc.CountryCode,
    					Description = itg.Description,
    					AppliesToAllCountries = itc.CountryCode.Equals("XX") ? true : false
    				};
    var serverQueryResult = query.ToList();
    var clientQuery = from r in serverQueryResult
    				  select new ValueObjects.IR.IRTransactionGroupLink 
    				  {
    					  IRTransactionGroupType = EnumHelper.Parse<IRTransactionGroupTypeEnum>(r.Group.Trim(), true),
    					  CountryCode = r.CountryCode,
    					  Description = r.Description,
    					  AppliesToAllCountries = r.AppliesToAllCountries
    				  };
