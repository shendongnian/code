    var classOnlyMale = dbContext.Set<ClassEntity>()
                                 .Where(x => x.Id == classId)
                                 .Select(x => new 
                                              {
                                                Id = x.Id
                                                Students = x.Students
                                                            .Where(y => y.Gender == GenderEnum.Male)
                                                            .Select(y => new { Name = y.Name, ... })
                                              });
