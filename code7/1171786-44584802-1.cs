    using System;
    public class Example
    {
       public static void Main()
       {
          var name = "Horace";
          var age = 34;
          // replaces {name} with the value of name, "Horace"
          var s1 = $"He asked, \"Is your name {name}?\", but didn't wait for a reply.";
          Console.WriteLine(s1);
      
          // as age is an integer, we can use ":D3" to denote that
          // it should have leading zeroes and be 3 characters long
          // see https://docs.microsoft.com/en-us/dotnet/standard/base-types/how-to-pad-a-number-with-leading-zeros
          //
          // (age == 1 ? "" : "s") uses the ternary operator to 
          // decide the value used in the placeholder, the same 
          // as if it had been placed as an argument of string.format
          var s2 = $"{name} is {age:D3} year{(age == 1 ? "" : "s")} old.";
          Console.WriteLine(s2); 
       }
    }
    // The example displays the following output:
    //       He asked, "Is your name Horace?", but didn't wait for a reply.
    //       Horace is 034 years old.
