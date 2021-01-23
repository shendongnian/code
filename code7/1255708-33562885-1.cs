    using System;
    using System.Collections.Generic;
    using System.Collections;
     using System.Linq;
    using System.Text;
    namespace LambdaPractice
    {
    class Program
    {
        static int[,] c;
      
       static int max(int a, int b)
        {
            return (a > b) ? a : b;
        }
                
       static int LCS(string s1, string s2)
        {
            for (int i = 1; i <= s1.Length; i++)
                c[i,0] = 0;
            for (int i = 1; i <= s2.Length; i++)
                c[0, i] = 0;
            for (int i=1;i<=s1.Length;i++)
                for (int j = 1; j <= s2.Length; j++)
                {
                    if (s1[i-1] == s2[j-1])
                        c[i, j] = c[i - 1, j - 1] + 1;
                    else
                    {
                        c[i, j] = max(c[i - 1, j], c[i, j - 1]);
                            
                    }
                }
            return c[s1.Length, s2.Length]; 
        }
