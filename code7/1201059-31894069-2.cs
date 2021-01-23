    //using System;
    
    namespace Ns
    {
        public class Program
        {
            static void Main(string[] args)
            {
                System.Int32 i = 2;    //OK, since we explicitly specify the System namespace
                int j = 2;             //alias for System.Int32, so this is OK too
                Int32 k = 2;           //Error, because we commented out "using System"
            }
        }
    }
