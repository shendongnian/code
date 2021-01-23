     IQueryable<BaseDto> baseQuery = GetBaseQuery();
    
     IQueryable<SubclassDto> query = from baseDto in baseQuery                                  
                                     let moreData = DataContext.vMoreData.FirstOrDefault(x => x.Id == baseDto.Id) 
                                     select baseDto.AutoProjectInto(() => new SubclassDto()
                                     {
                                      NewProp1 = moreData.Foo,
                                      NewProp2 = moreData.Baz,
                                      OldProp1 = moreData.SomeOverridingData
                                     });
    
     IQueryable<SubclassDto> activateQuery = query.ActivateAutoProjects(); 
