    IEnumerable<Student> GetStudentsHavingSubject(string subjectCode, string curUser)
    {
        var Students = this.GetFilteredQueryable<Student>(CurUser);
        Students = Students.Where(x => x.subjects.Any(y=>y.SubjectCode == subjectCode));
        return Students.
    }
    
    IEnumerable<Student> GetFilteredQueryable(curUser)
    {
        var Students = DB.Students.Where(x => x.Organization.Users.Any(y=>y.UserName == curUser));
    }
