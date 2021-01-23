    using System;
    
    public class Test
    {    
        static void Main()
        {
    #pragma warning disable CS0612        
            ObsoleteMethod();
    #pragma warning restore CS0612        
        }
        
        [Obsolete]
        static void ObsoleteMethod()
        {
        }
    }
