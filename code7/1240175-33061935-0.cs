        var data =
            (from result in results
             group result by new { result.StudentId, result.FirstName, result.LastName, result.MiddleInitial } into StudentGroup
             select new
             {
                 StudentId = StudentGroup.Key.StudentId,
                 FullName = string.Format("{0} {1} {2}", StudentGroup.Key.FirstName, StudentGroup.Key.MiddleInitial, StudentGroup.Key.LastName).Replace("  ", " "),
                 Classes = (from s in StudentGroup
                            group s by new { s.ClassId, s.ClassName } into ClassGroup
                            select new
                            {
                                ClassId = ClassGroup.Key.ClassId,
                                ClassName = ClassGroup.Key.ClassName,
                                ClassCategories = (from c in ClassGroup
                                                   group c by new { c.CategoryName, c.CategoryWeight } into CategoryGroup
                                                   select new
                                                   {
                                                       CategoryName = CategoryGroup.Key.CategoryName,
                                                       CategoryWeight = CategoryGroup.Key.CategoryWeight,
                                                       Assignments = (from ct in CategoryGroup
                                                                      group ct by new { ct.AssignmentName, ct.Score } into AssingnmentGroup
                                                                      select new
                                                                      {
                                                                          AssignmentName = AssingnmentGroup.Key.AssignmentName,
                                                                          Score = AssingnmentGroup.Key.Score
                                                                      }).ToList()
                                                   }).ToList()
                            }).ToList()
             }).ToList();
