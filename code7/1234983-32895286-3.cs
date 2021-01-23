    namespace MyNameSpace
    {
        class FirstClass
        {
            public static FirstClass singleton;
            public string some_public_data;
            public FirstClass()
            {
                this.some_public_data = "some data";
                singleton = this; //works for only one instance in given moment
                                  //last one, OK?
            }
        }
        class SecondClass
        {
            public DoSomethingWithFirstClass()
            {
                 FirstClass first_class = FirstClass.singleton;
                 Console.WriteLine(first_class.some_public_data);
            }
        }
        class Program
        {
             static void Main()
             {
                 new FirstClass();//instance will be stored in static singleton
                 SecondClass second_class = new SecondClass();
                 second_class.DoSomethingWithFirstClass()
             }
        }
    }
