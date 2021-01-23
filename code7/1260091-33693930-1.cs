    var classOnlyMale = dbContext.Set<ClassEntity>()
                                 .Where(x => x.Id == classId)
                                 .Select(x => new // I'm using an anonymous type here, but you can (and usually should!) project onto a DTO instead
                                              {
                                                // It's usually best to only get the data you actually need!
                                                Id = x.Id
                                                Students = x.Students
                                                            .Where(y => y.Gender == GenderEnum.Male)
                                                            .Select(y => new { Name = y.Name, ... })
                                              });
