    class Program
    {
        static Type _type = typeof(char); // Store Type as field.
    
        static void Main()
        {
    	Console.WriteLine(_type); // Value type pointer
    	Console.WriteLine(typeof(int)); // Value type
    	Console.WriteLine(typeof(byte)); // Value type
    	Console.WriteLine(typeof(Stream)); // Class type
    	Console.WriteLine(typeof(TextWriter)); // Class type
    	Console.WriteLine(typeof(Array)); // Class type
    	Console.WriteLine(typeof(int[])); // Array reference type
        }
    }
