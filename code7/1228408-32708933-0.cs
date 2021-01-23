    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace test4
    {
    class Program
    {
        static void Main(string[] args)
        {
            List<double> arrayOfDouble = new List<double>(); // the array to insert into from console
            string strData = Console.ReadLine(); // the data, exmple: 123.32, 125, 78, 10
            string[] splittedStrData = strData.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            // trim then parse to souble, then convert to double list
            List<double> dataArrayAsDouble = splittedStrData.Select((s) => { return double.Parse(s.Trim()); }).ToList();
            // add the read array to your array
            arrayOfDouble.AddRange(dataArrayAsDouble);
        }
    }
    }
