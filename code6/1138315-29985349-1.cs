    using System;
    
    public class Test
    {    
        static void Main()
        {
    #pragma warning disable CS0618       
            ObsoleteMethod();
    #pragma warning restore CS0618        
        }
        
        [Obsolete("Don't call me")]
        static void ObsoleteMethod()
        {
        }
    }
