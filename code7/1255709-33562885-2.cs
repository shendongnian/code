            if (i == 0 || j == 0)
                return "";
            if (s1[i - 1] == s2[j - 1])
                return BackTrack(s1, s2, i - 1, j - 1) + s1[i - 1];
            else if (c[i - 1, j] > c[i, j - 1])
                return BackTrack(s1, s2, i - 1, j);
            else
                return BackTrack(s1, s2, i, j - 1);
        }*/
       static SortedSet<string> backtrack(string s1, string s2, int i, int j)
       {
           if (i == 0 || j == 0)
               return new SortedSet<string>(){""} ;
           else if (s1[i - 1] == s2[j - 1])
           {
               SortedSet<string> temp = new SortedSet<string>();
               SortedSet<string> holder = backtrack(s1, s2, i - 1, j - 1);
               if (holder.Count == 0)
               {
                  temp.Add(s1[i - 1]);
               }
               foreach (string str in holder)
                    temp.Add(str + s1[i - 1]);
               
               return temp;
           }
           else
           {
               SortedSet<string> Result = new SortedSet<string>() ;
               if (c[i - 1, j] >= c[i, j - 1])
               {
                   SortedSet<string> holder = backtrack(s1, s2, i - 1, j);
               
                   foreach (string s in holder)
                       Result.Add(s);
               }
               if (c[i, j - 1] >= c[i - 1, j])
               {
                   SortedSet<string> holder = backtrack(s1, s2, i, j - 1);
               
                   foreach (string s in holder)
                       Result.Add(s);
               }
               return Result;
           }
       }
        static void Main(string[] args)
        {
                string s1, s2;
                s1 = Console.ReadLine();
                s2 = Console.ReadLine();
                c = new int[s1.Length+1, s2.Length+1];
                LCS(s1, s2);
                // Console.WriteLine(BackTrack(s1, s2, s1.Length, s2.Length));
                //  Console.WriteLine(s1.Length);
                SortedSet<string> st = backtrack(s1, s2, s1.Length, s2.Length);
               
                foreach (string str in st)
                    Console.WriteLine(str);
                GC.Collect();
              
           Console.ReadLine();
        }
    }
    }
