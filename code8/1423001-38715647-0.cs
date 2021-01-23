    using System;
    namespace Task2
    {
        class BirthDate
        {
           static void Main(string[] date)
           {
               Console.WriteLine("Please enter your month of birth:");
               var Month = Console.ReadLine();
               Console.WriteLine("Please enter your day of birth:");
               var Day = Console.ReadLine();
               Console.WriteLine("Your birth month is {0}, on day {1}", Month, Day);
               Console.ReadLine();
           }
        }
    }
