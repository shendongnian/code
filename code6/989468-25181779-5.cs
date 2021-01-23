    interface Course {
       public String getCourseName();
    }
    public abstract class GradedCourse implements Course {
    ... 
    }
    
    
    GradedCourseA extends GradedCourse {
    ...
    }
    GradedCourseB extends GradedCourse {
    ...
    }
    
    public abstract class NonGradedCourse implements Course {
    ... 
    }
    NonGradedCourseA extends NonGradedCourse {
    ...
    }
    NonGradedCourseB extends NonGradedCourse {
    ...
    }
