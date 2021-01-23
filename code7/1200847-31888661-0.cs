    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication41
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<MyAppliance> myAppliance = new List<MyAppliance>();
            }
        }
        public class MyAppliance
        {
            public Appliance appliance { get; set; }
            public ApplianceUI applianceUI { get; set; }
        }    
    }
