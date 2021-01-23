    class OutExample
    {
        static void Method(out int i)
        {
            i = 44;
        }
        static void MethodWrapper() 
        {
            int i = 0;
            Method(i);
        }
        static void Main()
        {
            int value;
            Method(out value);
            // value is now 44
            MethodWrapper();
            // No value needed to be passed - function is wrapped. Method is still called within MethodWrapper, however.
        }
    }
