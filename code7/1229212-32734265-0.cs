    public interface IAwesome
    {
        int ID { get; }
    }
    public class MegaClass : IAwesome
    {
        public int ID { get; set; }
        ...
    }
    public class SuperClass : IAwesome
    {
        public int ID { get; set; }
        ...
    }
