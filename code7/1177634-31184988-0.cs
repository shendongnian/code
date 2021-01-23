    List<Course> courses = (from item in resultset
                           group new
                           {
                               item.CourseId,
                               item.CourseCode,
                               item.StudentId,
                               item.StudentNo,
                               item.StudentName,
                               item.StudentSurname
                           }
                           by new
                           {
                               CourseId = item.CourseId,
                               CourseCode = item.CourseCode
                           } into _item
                           select new Course
                           {
                               CourseId = _item.Key.CourseId,
                               CourseCode = _item.Key.CourseCode
                               EnrolledStudents  = (from st in resultset.Where(x => x.CourseId == _item.Key.CourseId)
                                                   select new Student
                                                   {
                                                       StudentId = st.StudentId,
                                                       StudentNo = st.StudentNo,
                                                       StudentName =  st.StudentName,
                                                       StudentSurname = st.StudentSurname
                                                   }).ToList()
                           }).ToList();
