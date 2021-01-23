    var query = from student in db.students
                        from course in student.Courses
                        group course by course.Name into g
                        select new
                        {
                            CourseName = g.Key,
                            Marks = g.Max(c => c.Score),
                            studentGroup = (
                                from student in db.students
                                let maxMark = g.Max(c => c.Score)
                                where student.Courses.Any(c => c.Name == g.Key && c.Score == maxMark)
                                select student
                            )
                        };
            foreach(var group in query)
            {
                Console.WriteLine("Course: {0}", group.CourseName);
                foreach (var student in group.studentGroup)
                {
                    Console.WriteLine("\t{0} {1} : {2}", student.First, student.Last, group.Marks);
                }
            }
