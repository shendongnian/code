     public class CourseSearchResultItem : SearchResultItem
     {
         [IgnoreIndexFieldAttribute]
         [IndexField("availabledatesforcourse")]
         public DateTime AvailableDatesForCourse { get; set;}
     }
