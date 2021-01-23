    List<AssignmentHistory> assignmentHistory = AYttFMConstsAndUtils.AssignmentHistList
                                           .Include(x => x.Student)
                                           .OrderBy(s => s.Student.StudentId)
                                           .ThenBy(w => w.WeekOfAssignment)
                                           .Select(x => 
                new { Field1 = x.field1, 
                      Field2 = x.field2..... 
                      StudentFirstName = StudentsList.Where(y => y.StudentId == x.AssignmentHistory.StudentID_FK).Select(c => c.FirstName).FirstOrDefault(),
                      StudentLastName = StudentsList.Where(y => y.StudentId == x.AssignmentHistory.StudentID_FK).Select(c => c.LastName).FirstOrDefault(),
                      StudentFullName = StudentsList.Where(y => y.StudentId == x.AssignmentHistory.StudentID_FK).Select(c => c.FirstName + " " + c.LastName).FirstOrDefault()}
    .ToList();
