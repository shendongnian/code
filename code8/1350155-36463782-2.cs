    public IEnumerable<Tuple<string, string>> ListAllCoursesWithArea()
    {
        return bookListLoader
                    .LoadList()
                    .GroupBy(x => x.CourseCode)
                    .Select(g => g.First())
                    .Select(x => new Tuple<string, string>(x.CourseCode, x.Area));
    }
