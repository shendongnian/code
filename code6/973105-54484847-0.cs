    using System.Linq;
    
    class Solution
    {
        public int solution(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            var i = 0;
            return A.Where(a => a > 0).Distinct().OrderBy(a => a).Any(a => a != (i = i + 1)) ? i : i + 1;
        }
    }
