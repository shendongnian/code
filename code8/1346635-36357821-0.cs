    public class Generic<T>
    {
        public void GenericMethod(T param)
        {
            Console.WriteLine(param.GetType().Name);
        }
    }
