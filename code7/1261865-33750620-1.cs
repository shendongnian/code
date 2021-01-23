    private viod GenerateStudentDetails(Student studentData)
    {
        var courses = m_courses.GetCoursesDictionary(); // returns Dictionary<Guid,string>()
    var studentDetails= (from data in studentData
            select new
            {
                FirstName = data.FirstName, 
                LastName = data.LastName,
                Email = data.Email,
                Mobile = data.Profile.Mobile,
                City = data.Profile.City,
                PostCode = data.Profile.PostCode,
                CourseID = data.Profile.CourseID
            }).AsEnumerable()
              .Select(item=>new
            {  
                FirstName = item.FirstName, 
                LastName = item.LastName,
                Email = item.Email,
                Mobile = item.Profile.Mobile,
                City = item.Profile.City,
                PostCode = item.Profile.PostCode,
                CourseName = courses[item.Profile.CourseID ?? Guid.Empty]
            });
    }
