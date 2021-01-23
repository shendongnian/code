    //Get complete list in postcodeEntry first
    postcodeEntry = transactieDataContext.PostcodeEntries
                        .Where(p => p.Postcode.ToUpper() == postcode.ToUpper())
                        .Where(p => p.NummerIsEven == isEven)
                        .Where(p => p.ScheidingHoog >= huisnummer)
                        .Where(p => p.ScheidingLaag <= huisnummer).ToList()
    
    //Then add Convert.ToDateTime() filter on list
    var requiredResult = postcodeEntry.where(p=> Convert.ToDateTime(p.StratDate) < DateTime.Now && Convert.ToDateTime(p.EndDate) > DateTime.Now).SingleOrDefault();
