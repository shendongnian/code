    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Reflection;
    
    namespace ReflectionWithLateBinding
    {
        public class Program
        {
            static void Main()
            {
                //load the current executing assembly
                Assembly executingAssembly1 = Assembly.GetExecutingAssembly();
    
                //load and instantiate the class dynamically at runtime - "Calculator class"
                Type calculatorType1 = executingAssembly1.GetType("ReflectionWithLateBinding.Calculator");
    
    
                //Create an instance of the type --"Calculator class"
                object calculatorInstance1 = Activator.CreateInstance(calculatorType1);
    
                //Get the info of the method to be executed in the class
                MethodInfo sumArrayMethod1 = calculatorType1.GetMethod("SumArray");
    
                int[] numbers = { 5, 8, 2, 1 };
                object[] arrayParams1 = { numbers };
    
                int sum1;
                //Call "SumArray" Method
                sum1 = (int)sumArrayMethod1.Invoke(calculatorInstance1, arrayParams1);
    
    
                Console.WriteLine("Sum = {0}", sum1);
    
                Console.ReadLine();
    
            }
        }
    
        public class Calculator
        {
            public int SumArray(int[] input)
            {
                int sum = 0;
                for (int i = 0; i < input.Length; i++)
                {
                    sum += input[i];
                }
                return sum;
            }
        }
    }
