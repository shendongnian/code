    class Program
    {
        static void Main(string[] args)
        {
            dynamic anythingGoes = 1;
            var convertedToInt = ConvertToType<int>(anythingGoes);
            // expectation: should output Int32. and it does....
            Console.WriteLine(convertedToInt.GetType().Name);
            anythingGoes = "ribbit";
            var convertedToString = ConvertToType<string>(anythingGoes);
            // expectation: should output String. and it does also...
            Console.WriteLine(convertedToString.GetType().Name);
            Console.ReadLine();
        }
        // just a small method to cast the dynamic to whatever i want
        // ...only for this test. not guaranteed to be crash safe. in fact, don't assume!
        static T ConvertToType<T>(dynamic obj)
        {
            T result = obj;
            return result;
        }
    }
