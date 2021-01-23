    namespace MyNameSpace
    {
        class FirstClass
        {
            public static FirstClass last_instance;
            public string some_public_data;
            public FirstClass()
            {
                this.some_public_data = "some data";
                last_instance= this;
                //keeps last created instance
            }
        }
        class SecondClass
        {
            public DoSomethingWithFirstClass()
            {
                 FirstClass first_class = FirstClass.last_instance;
                 Console.WriteLine(first_class.some_public_data);
            }
        }
        class Program
        {
             static void Main()
             {
                 new FirstClass();//last_instance will be stored
                 SecondClass second_class = new SecondClass();
                 second_class.DoSomethingWithFirstClass()
             }
        }
    }
