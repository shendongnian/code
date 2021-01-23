    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(WillDataTypeFit<short, int>());
            Console.WriteLine(WillDataTypeFit<int, short>());
        }
        static bool WillDataTypeFit<TTypeToCheck, TTypeToFitInto>()
            where TTypeToCheck : struct
            where TTypeToFitInto : struct 
        {
            TTypeToCheck typeToCheck = default(TTypeToCheck);
            dynamic test = typeToCheck;
            try
            {
                TTypeToFitInto toFitInto = test;
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
