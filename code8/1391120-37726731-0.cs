    using System.IO;
    using System;
    
    class Program
    {
        static void Main()
        {
            var str = "Bug C is resolved (Data issue) (SID: X017)";
            var index = str.IndexOf("ID: ");
            Console.WriteLine(index);
            // + 4 is the length of the string "ID: "
            // so again we are subtracting it back along with -1 to remove the last paranthesis
            str = str.Substring(index + 4, str.Length - index - 4 - 1);
            Console.WriteLine(str);
        }
    }
