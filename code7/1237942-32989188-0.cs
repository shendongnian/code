    var result = studentList.SelectMany(x => x.GroupList, 
                                          (studentObj, groups) => new { studentObj, groups })
                            .GroupBy(x => new { x.groups.GroupId, x.groups.GroupName })
                            .Select(x => new 
                                   {
                                      GroupId = x.Key.GroupId,
                                      GroupName = x.Key.GroupName,
                                      Students = x.Select(z => z.studentObj).ToList()
                                   });
