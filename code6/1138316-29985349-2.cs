    using System;
    
    public class Test
    {    
        static void Main()
        {
    #pragma warning disable 0618       
            ObsoleteMethod();
    #pragma warning restore 0618        
        }
        
        [Obsolete("Don't call me")]
        static void ObsoleteMethod()
        {
        }
    }
