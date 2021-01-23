    class Program
    {
        static void Main(string[] args)
        {
            DateTime dtNow = DateTime.Now;
            Console.WriteLine("String of float: " + getTheString<float>(12.7f));
            Console.WriteLine("String of DateTime: " + getTheString<DateTime>(dtNow));
            Console.WriteLine("The type name for a float number: " + getTheTypeName(18.25f));
            Console.WriteLine("The type name for a DateTime object: " + getTheTypeName(dtNow));
            Console.WriteLine("the result of making an instance for a float type: " + 
                makeOneInstanceOfType(20.2f, typeof(float)));
            Console.WriteLine("the result of making an instance for a DateTime type: " +
                makeOneInstanceOfType(0, typeof(DateTime)));
            //Using GetType() instead of typeof(..)
            Console.WriteLine("the result of making an instance for a DateTime type: " +
                          makeOneInstanceOfType(0, typeof(DateTime)));
            Console.ReadLine();
        }
        //Using the Type Parameter (T) for creating instances of T which T is your type,
        //specified when calling the method
        private static string getTheString<T>(T arg)
        {
            return arg+"";
        }
        //Using Type by calling the GetType() method of the object
        private static string getTheTypeName(object arg)
        {
            return arg.GetType().FullName;
        }
        //Direct use of Type, creates a float and fills is with the value if theType is float,
        //otherwise makes an instance of theType.
        private static object makeOneInstanceOfType(float valIfFloat, Type theType)
        {
            object instance;
            if(theType.IsEquivalentTo(typeof(float)))
            {                
                instance = valIfFloat;
            }
            else
            {
                instance = Activator.CreateInstance(theType);
            }
            return instance;
        }
    }
