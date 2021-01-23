    using System;
    using System.Collections;
    using System.Collections.Generic;
    
    
    public class QueueDemo
    {
        public static void Main(String[] args)
        {
            List<char> list1 = new List<char>{'A', 'S', 'D', 'F', 'G' };
            Queue<char> Q1 = new Queue<char>(list1);
            
            List<char> list2 = new List<char>{'S', 'A', 'D', 'G', 'Q' };
            Queue<char> Q2 = new Queue<char>(list2);
            
            foreach (char e in Q1)
            {
                if (!Q2.Contains(e))
                {
                    Console.WriteLine(e);
                }
            }
            
            foreach (char e in Q2)
            {
                if (!Q1.Contains(e))
                {
                    Console.WriteLine(e);
                }
            }
            
        }
    }
