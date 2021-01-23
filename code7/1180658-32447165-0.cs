    public class Event
    {
        [DataAnnotationsExtensions.Integer(ErrorMessage = "{0} must be a number.")]
        [Range(0,10),Required()]        
        public object Importance { get; set; }
        ...
    }
