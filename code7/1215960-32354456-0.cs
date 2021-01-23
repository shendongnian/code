    using System;
    using System.Text.RegularExpressions;
 
    public class Test
    {
        public static void Main()
        {
            var m = Regex.Match("3'üncü", @"([0-9]*)(([-/.]|[\w])([n][c][ıIiİuUüÜ]))|([0-9]*)(([-/.]|[\w])([ıIiİuUüÜ][n][c][ıIiİuUüÜ]))");
            Console.WriteLine(m.Success);
            Console.WriteLine(m.Value);
        }
    }
