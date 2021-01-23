    public interface ICrmService
    {
        string Url { get; set; }
    }
    
    public class CrmService : ICrmService
    {
        public string Url { get; set; }
    }
