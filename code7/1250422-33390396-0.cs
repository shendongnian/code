    //Excel sheet data
    var ListOfPropertyElements = dataInternal.Select(element => new { PersonName = DC.EncryptToString((string)element.PersonName),
                                                                      KeyDate = (DateTime)element.KeyDate }).Distinct();
        
    //Filtered Id's
    var idList = dbContext.tbl_person.Any(item => ListOfPropertyElements.Any(pElement => item.ItemName == pElement.PersonName && item.KeyDate == pElement.KeyDate))
                                     .Select(fItem => fItem.personID).ToList(); 
