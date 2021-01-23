    public class Test<T>
    {
        public static object obj = new object();
    }
    Console.WriteLine(object.ReferenceEquals(Test<string>.obj, Test<object>.obj)); // false
