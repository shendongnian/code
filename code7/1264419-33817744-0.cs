    enum TestEnum:int // Explicitly stating a type.
    {
        OnlyElement=0
    }
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine implicitly calls ToString of the TestEnum.OnlyElement.
            Console.WriteLine("OnlyElement == {0}", TestEnum.OnlyElement);
            //TestEnum.OnlyElement equals to 0, as demonstrated by this casting:
            Console.WriteLine("(int)OnlyElement == {0}", (int)TestEnum.OnlyElement);
            //We can do it in reverse...
            Console.WriteLine("(TestEnum)0 == ",(TestEnum)0); 
            // But what happens when we try to cast a value, which is not
            // representable by any of enum's named constants,
            // into value of enum in question? No exception is thrown 
            // whatsoever: enum variable simply holds that value, and, 
            // having no named constant to associate it with, simply returns
            // that value when attempting to "ToString"ify it:
            Console.WriteLine("(TestEnum)5 == {0}", (TestEnum)5); //prints "(TestEnum)5 == 5".
            
            Console.ReadKey();
        }
    }
