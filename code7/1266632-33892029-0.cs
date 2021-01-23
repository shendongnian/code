    public IEnumerable<Course> GetCourses(string languageCode)
        {
            return DbSet
                .Where(a => a.Active)
                .Include(a => a.CourseText)
                .Include(a => a.CourseText)
                .Where(b => b.CourseId == a.CourseId && b.LanguageCode == languageCode)
                ;
        }
