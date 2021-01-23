    using System.IO;
    using System;
    using  System.Text.RegularExpressions;
    class Program
    {
        static void Main()
        {
            String strLine="4	Sun		5	is		6	rising";
            String resultString = Regex.Replace(strLine, @"\d\t", "");
            resultString= Regex.Replace(resultString, @"\t\t", " ");
            Console.Write(resultString);
       }
    }
