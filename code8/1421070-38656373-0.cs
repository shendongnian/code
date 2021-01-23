    internal class Nested
    {
        protected class Class
        {   
            // Only usable from the Nested class
            internal void Method()
            {
                Console.WriteLine("Inside Method");
            }
        }
    }
}
