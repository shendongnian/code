    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    namespace Demo
    {
        // A List extension class for natural sorting.
        public static class ListExt
        {
            [DllImport("shlwapi.dll", CharSet = CharSet.Unicode)]
            private static extern int StrCmpLogicalW(string lhs, string rhs);
            // Version for lists of any type.
            public static void SortNatural<T>(this List<T> self, Func<T, string> stringSelector)
            {
                self.Sort((lhs, rhs) => StrCmpLogicalW(stringSelector(lhs), stringSelector(rhs)));
            }
            // Simpler version for List<string>
            public static void SortNatural(this List<string> self)
            {
                self.Sort(StrCmpLogicalW);
            }
        }
        // Demonstrate using the List extension.
    
        public class Program
        {
            private static void Main(string[] args)
            {
                List<string> names = new List<string>
                {
                    "abc.jpg",
                    "abc10.jpg",
                    "abc100.jpg",
                    "abc98.jpg",
                    "abc97.jpg",
                    "abc102.jpg",
                    "abc101.jpg"
                };
                names.SortNatural();
                foreach (var name in names)
                    Console.WriteLine(name);
            }
        }
    }
