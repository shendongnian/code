    using System;
    using System.Text.RegularExpressions;
    var regex = new Regex(@"^[a-zA-Z0-9]*$");
    Console.WriteLine(regex.IsMatch("asdf"));      // True
    Console.WriteLine(regex.IsMatch(""));          // True
    Console.WriteLine(regex.IsMatch("123abcABC")); // True
    Console.WriteLine(regex.IsMatch("&%&"));       // False
