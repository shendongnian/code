    public string GetPrimaryMajor(List<Student> students)
    {    
        var mostCommonMajor = students
                                  .GroupBy(m => m.Major)
                                  .OrderByDescending(gp => gp.Count())
                                  .FirstOrDefault()? // null-conditional operator
                                  .Select(s => s.Major)
                                  .FirstOrDefault();
        return mostCommonMajor;
    }
