    using System.IO;
    using System;
    using System.Text.RegularExpressions;
    
    public class Example
    {
       public static void Main()
       {
            var input ="[[[\"Bonjour, Ceci est un test!\",\"Hello, This is a test!\",,,0]],,\"en\"]";
            var parse = Regex.Split(input, "\\[|\\]|[^a-zA-Z ],|\",\"|\"|\"");
            foreach(var item in parse) {
                bool result = !String.IsNullOrEmpty(item) && (Char.IsLetter(item[0]) || Char.IsDigit(item[0]));
                if (result) {
                    Console.WriteLine(item);
                }
            }
       }
    }
