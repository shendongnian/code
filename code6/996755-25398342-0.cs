    using System.IO;
    using System.Linq;
    using System;
    
    class Program
    {
        static void Main()
        {
            int[] scores = { 4, 7, 9, 3, 8, 6 };
            Console.WriteLine(resoult(scores));
        }
        
        static int resoult(int[] pScores)
        {
            return pScores.Sum() - pScores.Max() - pScores.Min();
        }
    }
