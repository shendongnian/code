        Compare(List<string> a, List<string> b)
        {
            a.Sort();
            b.Sort();
            if(a.Length == b.Length)
            {
                for(int i = 0; i < a.Length; i++)
                {
                    if(a[i] != b[i])
                    {
                        return false;
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }
