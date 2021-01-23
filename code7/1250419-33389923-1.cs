    List<int> idList =  dbContext.tbl_person
                        .Where(item => ListOfPropertyElements.Select(x => x.PersonName)
                                                             .Contains(item.KeyDate) 
                                    && ListOfPropertyElements.Select(x => x.PersonName)
                                                             .Contains(item.KeyDate)))
                        .Select(item => item.personID).ToList();
