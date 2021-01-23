       using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    class Solution
    {
        static void Main(String[] args)
        {
            string[] inputs = { "GAAATAAA", "CACCGCTACCGC", "CAGCTAGC", "AAAAAAAA", "GAAAAAAA", "GATGAATAACCA", "ACGT" };
    
            List<string> replacement = new List<string>();
            foreach (var item in inputs)
            {
                replacement.Add(StringThatHasToBeReplaced(item));
            }
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
    
            if (pairs.Where(p => p.Value != div).Count() == 0)
            {
                return null;
            }
    
            List<char> surplusCharacter = pairs.Where(p => p.Value > div).Select(p => p.Key).ToList();
            int minLength = pairs.Where(p => p.Value > div).Sum(p => p.Value - div);
            string result = s;
            for (int i = 0; i < s.Length - minLength + 1; i++) // i is the start index
            {
                if (surplusCharacter.Contains(s[i]))
                {
                    if (minLength == 1)
                        return s[i].ToString();
    
                    for (int j = i + minLength - 1; j < s.Length; j++) // j is the end index
                    {
                        if (surplusCharacter.Contains(s[j]))
                        {
                            var substring = s.Substring(i, j - i);
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
