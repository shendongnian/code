         IQueryable<BaseDto> baseQuery = GetBaseQuery();
    
      IQueryable<SubclassDto> query = from baseDto in baseQuery
                                      let moreData = DataContext.vMoreData.FirstOrDefault(x => x.Id == baseDto.Id)
                                      select new SubclassDto()
                                      {
                                        NewProp1 = moreData.Foo,
                                        NewProp2 = moreData.Baz,
                                        OldProp1 = moreData.SomeOverridingData,
    
                                        OldProp2 = baseDto.OldProp2,
                                        OldProp3 = baseDto.OldProp3,
                                        OldProp4 = baseDto.OldProp4,
                                        //... 20 more projections from BaseDto to SubclassDto
                                      };
