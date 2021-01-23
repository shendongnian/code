    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace DivingChampionship_Coursework
    {
       class Program
    {
        static void Main(string[] args)
        {
            string[] divers = File.ReadAllLines(@"F:\1 -C# Programming\Coursework\DiverName.txt");
            int score1 = 0;
            int score2 = 0;
            int score3 = 0;
            int score4 = 0;
            int score5 = 0;
            Diver1(ref divers, ref score1);
            Diver2(ref divers, ref score2);
            Diver3(ref divers, ref score3);
            Diver4(ref divers, ref score4);
            Diver5(ref divers, ref score5);
            FindWinner(ref divers, ref score1, ref score2, ref score3, ref score4, ref score5);
        }
        static void Diver1(ref string[] divers, ref int score1)
        {
            int[] diver1 = new int[5];
            int max1 = 0;
            int min1 = 10;
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Please Enter a score for {0}", divers[0]);
                diver1[i] = Convert.ToInt16(Console.ReadLine());
                while (diver1[i] < 0 || diver1[i] > 10)
                {
                    Console.WriteLine("Opps, the score you have entered is incorrect, please enter valid score");
                    diver1[i] = Convert.ToInt16(Console.ReadLine());
                }
                if (diver1[i] < min1)
                {
                    min1 = diver1[i];
                }
                if (diver1[i] > max1)
                {
                    max1 = diver1[i];
                }
            }
            score1 = diver1[0] + diver1[1] + diver1[2] + diver1[3] + diver1[4] - max1 - min1;
            Console.WriteLine("Total score is {0} from {1}", score1, divers[0]);
            Console.WriteLine();
        }
        static void Diver2(ref string[] divers, ref int score2)
        {
            int[] diver2 = new int[5];
            int max2 = 0;
            int min2 = 10;
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Please Enter a score for {0}", divers[1]);
                diver2[i] = Convert.ToInt16(Console.ReadLine());
                while (diver2[i] < 0 || diver2[i] > 10)
                {
                    Console.WriteLine("Opps, the score you have entered is incorrect, please enter valid score");
                    diver2[i] = Convert.ToInt16(Console.ReadLine());
                }
                if (diver2[i] < min2)
                {
                    min2 = diver2[i];
                }
                if (diver2[i] > max2)
                {
                    max2 = diver2[i];
                }
            }
            score2 = diver2[0] + diver2[1] + diver2[2] + diver2[3] + diver2[4] - max2 - min2;
            Console.WriteLine("Total score is {0} from {1}", score2, divers[1]);
            Console.WriteLine();
        }
        static void Diver3(ref string[] divers, ref int score3)
        {
            int[] diver3 = new int[5];
            int max3 = 0;
            int min3 = 10;
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Please Enter a score for {0}", divers[2]);
                diver3[i] = Convert.ToInt16(Console.ReadLine());
                while (diver3[i] < 0 || diver3[i] > 10)
                {
                    Console.WriteLine("Opps, the score you have entered is incorrect, please enter valid score");
                    diver3[i] = Convert.ToInt16(Console.ReadLine());
                }
                if (diver3[i] < min3)
                {
                    min3 = diver3[i];
                }
                if (diver3[i] > max3)
                {
                    max3 = diver3[i];
                }
            }
            score3 = diver3[0] + diver3[1] + diver3[2] + diver3[3] + diver3[4] - max3 - min3;
            Console.WriteLine("Total score is {0} from {1}", score3, divers[2]);
            Console.WriteLine();
        }
        static void Diver4(ref string[] divers, ref int score4)
        {
            int[] diver4 = new int[5];
            int max4 = 0;
            int min4 = 10;
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Please Enter a score for {0}", divers[3]);
                diver4[i] = Convert.ToInt16(Console.ReadLine());
                while (diver4[i] < 0 || diver4[i] > 10)
                {
                    Console.WriteLine("Opps, the score you have entered is incorrect, please enter valid score");
                    diver4[i] = Convert.ToInt16(Console.ReadLine());
                }
                if (diver4[i] < min4)
                {
                    min4 = diver4[i];
                }
                if (diver4[i] > max4)
                {
                    max4 = diver4[i];
                }
            }
            score4 = diver4[0] + diver4[1] + diver4[2] + diver4[3] + diver4[4] - max4 - min4;
            Console.WriteLine("Total score is {0} from {1}", score4, divers[3]);
            Console.WriteLine();
        }
        static void Diver5(ref string[] divers, ref int score5)
        {
            int[] diver5 = new int[5];
            int max5 = 0;
            int min5 = 10;
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Please Enter a score for {0}", divers[4]);
                diver5[i] = Convert.ToInt16(Console.ReadLine());
                while (diver5[i] < 0 || diver5[i] > 10)
                {
                    Console.WriteLine("Opps, the score you have entered is incorrect, please enter valid score");
                    diver5[i] = Convert.ToInt16(Console.ReadLine());
                }
                if (diver5[i] < min5)
                {
                    min5 = diver5[i];
                }
                if (diver5[i] > max5)
                {
                    max5 = diver5[i];
                }
            }
            score5 = diver5[0] + diver5[1] + diver5[2] + diver5[3] + diver5[4] - max5 - min5;
            Console.WriteLine("Total score is {0} from {1}", score5, divers[4]);
            Console.WriteLine();
        }
        static void FindWinner(ref string[] divers, ref int score1, ref int score2, ref int score3, ref int score4, ref int score5)
        {
            int MaximumScore = 0;
            int x = 0;
            if (score1 > MaximumScore)
            {
                MaximumScore = score1;
            }
            if (score2 > MaximumScore)
            {
                MaximumScore = score2;
                x = 1;
            }
            if (score3 > MaximumScore)
            {
                MaximumScore = score3;
                x = 2;
            }
            if (score4 > MaximumScore)
            {
                MaximumScore = score4;
                x = 3;
            }
            if (score5 > MaximumScore)
            {
                MaximumScore = score5;
                x = 4;
            }
            Console.WriteLine("Max score is {0} from {1}", MaximumScore, divers[x]);
        }
    }
}
