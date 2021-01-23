    class Converter : IConverter
    {
        public void Convert<T>(T value)
        {
            if (typeof(T) == typeof(string) this.Convert((string) value);
            else Console.WriteLine("Generic Method " + value);
        }
    
        public void Convert(string value)
        {
            Console.WriteLine("String Method " + value);
        }
    }
