    IEnumerable<Student> GetStudentsHavingSubject(string subjectCode, string curUser)
    {
        var Students = this.GetFilteredQueryable<Student>(CurUser);
        Students = Students.Where(x => x.subjects.Any(y=>y.SubjectCode == subjectCode));
        return Students.AsEnumerable();
    }
    
    IQueryable<Student> GetFilteredQueryable(curUser)
    {
        //you could do any other checks in here too, like user level, permissions, etc.
        return DB.Students.Where(x => x.Organization.Users.Any(y=>y.UserName == curUser));
    }
