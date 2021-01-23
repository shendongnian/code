    public class Employee : IEmployeeSpecificUsage
    {
        public string firstName { get; }
        public string lastname { get; }
        public int age { get; }
        public string workTitle { get; }
        public string field1 { get; }
        public string field2 { get; }
        public string field3 { get; }
    }
    public interface IEmployeeSpecificUsage
    {
        public string firstName { get; }
        public string field1 { get; }
        public int age { get; }
    }
