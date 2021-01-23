    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication6
    {
        public delegate void ExampleDelegate();
        class Program
        {
            static void Main(string[] args)
            {
                ExampleDelegate sample1 = new ExampleDelegate(SampleMethod);
                ExampleDelegate sample2 = SampleMethod;
            }
    
            static void SampleMethod()
            {
    
            }
        }
    }
