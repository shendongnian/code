    using System.Collections.Generic;
    using ContosoUniversity.Models;
    namespace ContosoUniversity.ViewModels
    {
        public class InstructorIndexData
        {
         public PagedList.IPagedList<Instructor> Instructors { get; set; }
         public PagedList.IPagedList<Course> Courses { get; set; }
         public PagedList.IPagedList<Enrollment> Enrollments { get; set; }
        }
    }
