    public abstract class AbstractCourseFactory
    {
        publicAbstractCourse createCourse(String scheduleType)
        {
            Course objCourse = this.getCourse(ScheduleType);        
            objCourse.createCourseMaterial();
            objCourse.createSchedule();
            return objCourse;
        }
        public abstract Course getCourse(String scheduleType);
    }
