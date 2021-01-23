    using System;
    using System.Linq;
    ...    
    var stringArray = Console.ReadLine().Split(' ');
    var sum = stringArray.Sum(number => int.Parse(number));
    Console.WriteLine(sum);
