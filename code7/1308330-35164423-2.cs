    public interface IModel<out T> where T : class
    {
        T Value { get; }
    }
    public class Model<T> : IModel<T> where T : class
    {
        public T Value { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var foo = new Model<string>()
            {
                Value = "hello world",
            };
            IModel<object> boo = foo;
            Console.WriteLine(boo.Value);
        }
    }
