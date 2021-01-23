    public class WellViewModel
    {
       public WellViewModel()
       {
           Wells = new List<WellModel>();
           Annotaions = new List<AnnotationModel>();
       }
       public List<WellModel> Wells { get; set; }
       public List<AnnotationModel> Annotations { get; set; }  
    }
