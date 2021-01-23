    public class Generic<T>
    {
        public void PrintType(T param)
        {
            Console.WriteLine(param.GetType().Name);
        }
    }
