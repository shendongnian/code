    namespace BusinessLogic
    {
        public static IEnumerable<Course> GetCourses()
        {
            using (var db = new MyEntities())
            {
                return db.Courses
                    .Include(x => x.Lectures.Select(y => y.Students))
                    .Include(x => x.Tutors)
                    .ToList();
            }
        }
    }
