    IEnumerable<CreditsAllsExport> exportQuery =
       from s in db.CreditsAlls
       select new CreditsAllsExport
       {
          FiscalYear = s.FiscalYear,
          Campus = s.Campus,
          StudentName = s.StudentName,
          CourseID = s.CourseID,
          CourseTitle = s.CourseTitle,
          CreditEarned = s.CreditEarned,
          DateEarned = s.DateEarned,
          Department = s.Department,
          School = s.School,
          Teacher = s.Teacher,
          /* I had forgotten this column*/ Transfer=s.Transfer,  
          CampusSchoolMatch = s.CampusSchoolMatch
      };
