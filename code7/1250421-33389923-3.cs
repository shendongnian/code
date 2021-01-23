    List<int> idList =  dbContext.tbl_person
                        .Where(item => ListOfPropertyElements.Select(x => x.PersonName)
                                                             .Contains(item.PersonName) 
                                    && ListOfPropertyElements.Select(x => x.KeyDate)
                                                             .Contains(item.KeyDate)))
                        .Select(item => item.personID).ToList();
