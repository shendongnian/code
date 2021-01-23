    public interface ISomeService
    {
        string ServiceValue { get; set; }
    }
    public class ServiceImplementation : ISomeService
    {
        public ServiceImplementation()
        {
            ServiceValue = "Injected from Startup";
        }
        public string ServiceValue { get; set; }
    }
