    public CourseFactoryGradedCourses extends AbsctractCourseFactory {
       public Course getCourse(String scheduleType) {
          if (scheduleType.equals("A") {
             return new GradedCourseA ();
          } else if (scheduleType.equals("B") {
             return new GradedCourseB ();
          }
       }
    }
    
    public CourseFactoryNonGradedCourses extends AbsctractCourseFactory {
       public Course getCourse(String scheduleType) {
          if (scheduleType.equals("A") {
             return new NonGradedCourseA ();
          } else if (scheduleType.equals("B") {
             return new NonGradedCourseB ();
          }
       }
    }
