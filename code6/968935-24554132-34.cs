    var result = (from cs in context.CollegeDetails
                          select new
                          {
                              cs.CollegeName,
                              // ...
                              cs.CreatedBy
                          }
                 )
                 .Select(c => new CollegeDetail
                              {
                                  CollegeName = c.CollegeName,
                                  // ...
                                  CreatedBy = c.CreatedBy
                              }
                        );
