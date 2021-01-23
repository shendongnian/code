    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                M1();
            }
            catch (Exception e)
            {
                throw;
            }
        }
        private static void M1()
        {
            try
            {
                M();
            }
            catch (Exception e)
            {
                throw new ExceptionWrapper(e);
            }
        }
        static void M()
        {
            throw new Exception("test exception");
        }
    }
