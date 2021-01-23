    var innerJoin = from e in db.Enrollments
                    join s in db.Student on e.StudentID equals s.StudentID
                    select e;
    var model = new List<dynamic>();
    foreach(var l in innerJoin)
	{
		dynamic temp = new System.Dynamic.ExpandoObject();
		temp.Student = l.StudentID;
		temp.Course = l.CourseID;
		model.Add(temp);
	}
			
