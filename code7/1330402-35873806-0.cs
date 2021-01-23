            string s1 = "abc"; string s2 = "def"; string s3 = "ghi";
            string findMe = "12ABC34";
            for (var windowSize = 1; windowSize <= findMe.Length; windowSize++)
            {
                for (var startIndex = 0; startIndex <= findMe.Length; startIndex++)
                {
                    if (startIndex + windowSize <= findMe.Length)
                    {
                        var findMeSubstring = findMe.Substring(startIndex, windowSize);
                        //Console.WriteLine(findMeSubstring);
                        foreach (var s in new List<string>() { s1, s2, s3 })
                        {
                            if (Regex.IsMatch(s,findMeSubstring, RegexOptions.IgnoreCase))
                            { /*return true;*/ Console.WriteLine($"Pattern {findMeSubstring} found in string {s}."); }
                        }
                    }
                }
            }
