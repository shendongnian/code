    public interface IHuman
    {
        int Id { get; set; }
        string Name { get; set; }
        bool IsVerified { get; set; }
    }
    public class Teacher : IHuman
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsVerified { get; set; }
    }
    public class Student : IHuman
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsVerified { get; set; }
    }
