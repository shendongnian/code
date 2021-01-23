    public class ResponseModel
    {
       public string Id { get; set;}
       public List<Well> Wells { get; set;}
       public string ExternalKey { get; set;}
    }
    
    public class Well
    {
       public string WellNumber { get; set;}
    }
