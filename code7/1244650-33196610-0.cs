        static void Main(string[] args)
        {
            calculator calc = new calculator();
            var addition = calc.GetType().GetMethod("addition", System.Reflection.BindingFlags.NonPublic  
                                                              | System.Reflection.BindingFlags.Instance);
    
            var result = addition.Invoke(calc, new object[] { 5, 10 });
            Console.WriteLine(result);
        }
