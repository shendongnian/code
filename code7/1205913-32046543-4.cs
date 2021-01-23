    public interface IRevisable
    {
       DateTime RevisedDate { get; set; }
       User RevisedBy { get; set; }    
    }
    public class Request: IRevisable
    {
    }
    public class Material: IRevisable
    {
    }
