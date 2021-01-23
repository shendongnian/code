    using System;
    namespace RoslynTest
    {
        public class Test
        {
            public void Foo()
            {
                try
                {
                    var x = 0;
                }
                catch
                {
                    
                }
            }
    
            public void Bar()
            {
                try
                {
                    var x = 0;
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
    
    
            public void Baz()
            {
                try
                {
                    var x = 0;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
