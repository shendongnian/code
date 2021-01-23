    class Converter : IConverter
    {
        public void Convert<T>(T value)
        {
            if (value is string)
            {
                Console.WriteLine("String Method " + (string)value);
            }
            else
            {
                Console.WriteLine("Generic Method " + value);
            }
        }
    }
