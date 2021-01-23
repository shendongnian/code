    var result = (from cs in context.CollegeDetails
                          select new CollegeDetail
                          {
                              CollegeName = cs.CollegeName,
                              // ...
                              CreatedBy = cs.CreatedBy
                          }
                 )
                 .Select(c => new CollegeDetail
                              {
                                  c.CollegeName,
                                  // ...
                                  c.CreatedBy
                              }
                        ).ToList();
