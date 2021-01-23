    static class Program
    {
        static void Main(string[] args)
        {
            A(1);
        }
        private static void A(int i)
        {
            try
            {
                B(i + 1);
            }
            catch (Exception ex)
            {
                if (ex.Message != "!")
                    Console.WriteLine(ex);
                else throw;
            }
        }
        private static void B(int i)
        {
            throw new Exception("!");
        }
    }
