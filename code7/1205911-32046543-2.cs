    public interface IRevicable 
    {
       DateTime RevisedDate { get; set; }
       User RevisedBy { get; set; }    
    }
    public class Request: IRevicable 
    {
    }
    public class Material: IRevicable 
    {
    }
