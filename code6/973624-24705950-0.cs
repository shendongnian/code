    using System;
    class Test
    {
        bool value = DateTime.Now.Hour == 10;
        
        void Cast()
        {
            if (((Func<bool>)(() => value))())
            {
                Console.WriteLine("Yes");
            }
        }
    
        void New()
        {
            if (new Func<bool>(() => value)())
            {
                Console.WriteLine("Yes");
            }
        }
        
        static void Main()
        {
            new Test().Cast();
            new Test().New();
        }
    }
