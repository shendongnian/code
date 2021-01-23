    internal class Program
    {
        private static void Main()
        {
            Test test = new Test();
            for (int i = 0; i < 3; i++)
            {
                try
                {
                    test.ThrowSomeException(i);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                }
            }
        }
    }
    public class Test
    {
        public void ThrowSomeException(int arg)
        {
            
            Console.WriteLine("arg = {0}", arg);
            switch (arg)
            {
                case 0:
                    {
                        Exception ex = new Exception("Line number = 36");
                        throw ex;
                    }
                case 1:
                    {
                        Exception ex = new Exception("Line number = 41");
                        throw ex;
                    }
                default:
                    {
                        Exception ex = new Exception("Line number = 46");
                        throw ex;
                        
                    }
            }
            
        }
    }
