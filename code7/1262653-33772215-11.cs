    public interface IHuman
    {  
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
