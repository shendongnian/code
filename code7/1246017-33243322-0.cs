    //other code
    foreach (string p in pattern1)
    {
        foreach (string s in sentences)
        {            
            //wrap your pattern in word boundaries
            string pat = "\b" + p + "\b"
            
            //use the new wrapped pattern
            if (System.Text.RegularExpressions.Regex.IsMatch(s, pat, System.Text.RegularExpressions.RegexOptions.IgnoreCase))
            {
                System.Console.WriteLine("  (match for '{0}' found)", pat);
            }
            else
            {
                //...
            }
        }
    }
