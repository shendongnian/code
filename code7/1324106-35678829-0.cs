    using (var context = new YourDbContext())
    {
     Student student = LINQ2ObjectsCode.GetStudentForId(context, ah.StudentID_FK);
     // Update several members of the Students list...
     student.WeekOfLastAssignment = _currentWeek;
     int nextTalkTypeId =  
     AYttFMConstsAndUtils.GetNextTalkIDForBrothers(ah.StudentID_FK, 1); 
     student.RecommendedNextTalkTypeID = nextTalkTypeId;
     student.NextCounselPoint = LINQ2ObjectsCode.GetNextCounselPoint(nextTalkTypeId,  
     student.NextCounselPoint);
    
     context.SaveChanges(); // ef
    }
