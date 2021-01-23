    class Program
    {
        static void Main(string[] args)
        {
            var wrapper = new Wrapper<Client>();
            string result;
            wrapper.Invoke(c => c.Convert, 5, out result);
        }
    }
