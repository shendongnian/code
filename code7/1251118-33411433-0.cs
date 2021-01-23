    public ActionResult Schedule()
    {
        int[] hours = { 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
        using (ApsContext db = new ApsContext())
        {
            List<TCourse> courses = new List<TCourse>();
            List<TClasssroom> clasRooms = new List<TClasssroom>();
            int lastScheduleId = 0;
            courses = db.TCourse.OrderBy(x => x.Quota).ToList();
            foreach (var itemCourse in courses)
            {
                var classRoomList = db.Classroom.Where(x => x.PlanID == lastScheduleId && x.Capacity >= itemCourse.Quota).OrderBy(x =< x.Capacity);
				 
				 TClasssroom availableClassRoom;
				
				foreach(TClasssroom classRoom in classRoomList)
				{
					List<TCourseClassroom> courseClassroomList = db.TCourseClassroom.FindAll(x => x.ClassroomID == clasRoom.ClassroomID);
					foreach(CourseClassroom courseClassroom in courseClassroomList)
					{
						if(!((course.StartHour > courseClassroom.StartHour &&  course.StartHour < courseClassroom.EndHour) ||
						(course.EndHour < courseClassroom.StartHour &&  course.EndHour > courseClassroom.EndHour)))
						{
							availableClassRoom = classRoom;
						}
					}								
				}
                if (availableClassRoom != null)
                {
                    var courseId = itemCourse.CourseID;
                    var classRoomId = clasRoom.ClassroomID;
                    var scheduleId = itemCourse.ScheduleID + 1;
                    db.Entry(classRoom).Entity.ScheduleID = scheduleId;
                    db.SaveChanges();
                    CourseClassroom newCourseClassroom = new CourseClassroom();
                    newCourseClassroom.CourseID = courseId;
                    newCourseClassroom.ClasssroomID = classRoomId;
                    newCourseClassroom.ScheduleID = scheduleId;
                    db.TCourseClassroom.Add(newCourseClassroom);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Schedule");
        }
    }
