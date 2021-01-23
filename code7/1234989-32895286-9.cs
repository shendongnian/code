    namespace MyNameSpace
    {
        class FirstClass
        {
            public static string some_public_static_data;
            public FirstClass()
            {
                some_public_static_data = "some static data";
            }
        }
        class SecondClass
        {
            public DoSomethingWithStaticDataOfFirstClass()
            {
                 Console.WriteLine(FirstClass.some_public_static_data);
            }
        }
        class Program
        {
             static void Main()
             {
                 new FirstClass();//it just updates static data
                 SecondClass second_class = new SecondClass();
                 second_class.DoSomethingWithStaticDataOfFirstClass()
             }
        }
    }
