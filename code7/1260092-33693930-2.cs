    var classOnlyMale = dbContext.Set<ClassEntity>()
                                 .Where(x => x.Id == classId)
                                 .Select(x => new
                                              {
                                                Class = x,
                                                MaleStudents = x.Students.Where(y => y.Gender == GenderEnum.Male)
                                              });
