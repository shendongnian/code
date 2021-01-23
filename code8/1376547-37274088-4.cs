    public class UseCase
    {
        public string UseCaseId { get; set; }
        public string UseCaseDescription { get; set; }
    }
    public class RootObject
    {
        public List<UseCase> UseCases { get; set; }
    }
