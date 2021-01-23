    //FirstClass.cs
    namespace FirstNameSpace
    {
        class FirstClass
        {
        }
    }
    
    //SecondClass.cs
    using FirstNameSpace; //this only makes FirstClass visible inside this file
    namespace SecondNameSpace
    {
        class SecondClass
        {
            public DoSomething()
            {
                 FirstClass first = new FirstClass();
            }
        }
    }
