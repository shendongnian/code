    using System;
    
    namespace Program
    {
      // this is a class. Because there are no free functions in C#,
      // everything has to be in a class.
      internal static class LeapYearFinderApplication
      {
        // this is the main entry point for your application
        internal static void Main()
        {
          Console.WriteLine("Enter the Year in Four Digits : ");
    
          var inputYear = Convert.ToInt32(Console.ReadLine()); 
    
          var inputYearIsLeapYear = IsLeapYear(inputYear);
    
          if (inputYearIsLeapYear)
          {
            Console.WriteLine("{0} is a Leap Year", inputYear);
          }
          else
          {
            Console.WriteLine("{0} is not a Leap Year", inputYear);
          }
    
          Console.ReadLine();
        }
    
        internal static bool IsLeapYear(int year)
        {
          return (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);
        }
      }
    }
