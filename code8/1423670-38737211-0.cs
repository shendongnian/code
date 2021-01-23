        foreach(var ss in subsets)
        {
             foreach(int n in S.Where(q => !ss.Contains(q)))
             {
                if(ss.All(m => (m + n) % k != 0))
                   ss.Add(n);
             }
         //Add the subset ss to subsets or replace it
        }
