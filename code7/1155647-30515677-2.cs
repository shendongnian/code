    public class Test : ITest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string GetName()
        {
            return Name;
        }
        public int GetId()
        {
            return Id;
        }
    }
    public interface ITest
    {
        string GetName();
    }
