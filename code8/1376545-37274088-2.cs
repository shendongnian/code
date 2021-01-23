    public class UseCase1
    {
        public string UseCaseId { get; set; }
        public string UseCaseDescription { get; set; }
    }
    public class UseCase2
    {
        public string UseCaseId { get; set; }
        public string UseCaseDescription { get; set; }
    }
    public class RootObject
    {
        public UseCase1 UseCase1 { get; set; }
        public UseCase2 UseCase2 { get; set; }
    }
