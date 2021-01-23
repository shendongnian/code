    using System;
    namespace ConsoleSample
    {
        [MySample(Property1 = "Something")]
        class Program
        {
            static void Main(string[] args)
            {
            }
        }
        public class MySampleAttribute : Attribute
        {
            public string Property1 { get; set; }
        }
    }
