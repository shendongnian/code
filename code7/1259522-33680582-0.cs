    using System;
    using System.Reflection;
    
    namespace JazzyNamespace
    {
        class Program
        {
            static void Main()
            {
                var reflectionExample = new ReflectionExample();
                // access the compiled value of our field
                var initialValue = reflectionExample.fieldToTest;
    
                // use reflection to access the readonly field
                var field = typeof(ReflectionExample).GetField("fieldToTest", BindingFlags.Public | BindingFlags.Instance);
    
                // set the field to a new value during
                field.SetValue(reflectionExample, 75);
                var reflectedValue = reflectionExample.fieldToTest;
    
                // demonstrate the change
                Console.WriteLine("The complied value is {0}", initialValue);
                Console.WriteLine("The value changed is {0}", reflectedValue);
                Console.ReadLine();
            }
    
        }
    
        class ReflectionExample
        {
            public readonly int fieldToTest;
    
            public ReflectionExample()
            {
                fieldToTest = 5;
            }
        }
    }
