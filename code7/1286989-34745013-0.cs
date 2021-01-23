    public class Application
    {
        public int Id {get; set;}
        public string Name {get; set;}
        public ApplicationType {get; set;}
        public IEnumerable<string> ApplicationProperties {get; private set;}
    }
