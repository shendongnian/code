    class Program
    {
        static void Main(string[] args)
        {
            var wrapper = new Wrapper<Client>();
            string result = wrapper.Invoke<int, string>(c => c.Convert, 5);
        }
    }
