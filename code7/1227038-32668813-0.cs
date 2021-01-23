	var beginDateTime = Convert.ToDateTime("2013-04-24 17:47:03");
	var endDateTime = Convert.ToDateTime("2013-05-24 17:47:03");
	var schoolYearBeginDate = DateTime.Parse("15/09/2015");
	var Schedules = new List<Schedule>
	{
		new Schedule
		{ 
			Day="Lundi", 
			Note="note", 
			Begin = beginDateTime, 
			End=endDateTime,
			ClassId = context.Classes.Where(c=>c.Libel=="Class 1").FirstOrDefault().Id, 
			SubjectLevelId = context.SubjectLevels.Where(cbv=>cbv.Coef==1).FirstOrDefault().Id, 
			ClassRoomId = context.ClassRooms.Where(c=>c.Libel=="ClassRoom1").FirstOrDefault().Id, 
			TeacherId = context.Teachers.Where(c=>c.FirstName=="mouna").FirstOrDefault().Id, 
			SchoolYearId=  context.SchoolYears.Where(f=>f.Begin==schoolYearBeginDate).FirstOrDefault().Id
		},
	};
