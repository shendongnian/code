    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    class Solution
    {
        static void Main(String[] args)
        {
            string str = "GAAATAAA";
            string ch = StringThatHasToBeReplaced(str);
            // you create a method that generate the replacement
            Console.WriteLine(ch.Length);
        }
    
        static string StringThatHasToBeReplaced(string s)
        {
            var counter = new Dictionary<char, int>() {
                { 'A', 0 }, { 'C', 0 }, { 'G', 0 }, { 'T', 0 }
            };
            for (int i = 0; i < s.Length; ++i)
                counter[s[i]] += 1;
    
            int div = s.Length / 4;
    
            var pairs = counter.ToList();
            List<char> surplusCharacter = pairs.Where(p => p.Value > div).Select(p => p.Key).ToList();
            int minLength = pairs.Where(p => p.Value > div).Sum(p => p.Value - div);
            string result = s;
            for (int i = 0; i < s.Length - minLength +1; i++) // i is the start index
            {
                if (surplusCharacter.Contains(s[i]))
                {
                    for (int j = minLength; j < s.Length; j++) // j is the end index
                    {
                        if (surplusCharacter.Contains(s[j]))
                        {
                            var substring = s.Substring(i, j -i);
                            if (substring.Length >= result.Length) 
                            {
                                break;
                            }
                            // we test if substring can be the string that need to be replaced
                            var isValid = true;
                            foreach (var c in surplusCharacter)
                            {
                                if (substring.Count(f => f == c) < counter[c] - div)
                                {
                                    isValid = false;
                                    break;
                                }
                            }
                            if (isValid)
                            result = substring;
                        }
                    }
                }
            }
            return result;
        }
    
      
    }
