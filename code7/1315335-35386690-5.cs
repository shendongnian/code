    public IEnumerable<string> getPermutation(string input, string regexp)
    {
            Stack<string> left = new Stack<string>();
            Stack<string> acc = new Stack<string>();
            left.Push(input);
            acc.Push("");
            // generate all permutations that match regexp
            while (left.Count > 0)
            {
                string c = left.Pop();
                string r = acc.Pop();
                if(r.Length==input.Length)
                {
                    yield return r;
                }
                else
                {
                    for(int i=0;i<c.Length;i++)
                    {
                        string p = r + c[i];
                        if (Regex.IsMatch(p,regexp)) // continue if we have a potential match
                        {
                            left.Push(c.Substring(0, i) + c.Substring(i + 1));
                            acc.Push(p);
                        }
                    }
                }
            }            
    }
    foreach(var a in getPermutation("123456789", "^3$|^32$|^321"))
    {
        if(Regex.IsMatch(a, "32145.67"))
        {
             // found match
        }
    }
