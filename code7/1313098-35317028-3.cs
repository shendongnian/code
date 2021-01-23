    using System.IO;
    using System.Linq;
    namespace Diving_Championship
    {
      class Program
      {
        private class Diver
        {
            internal Diver(string name)
            {
                Name = name;
            }
            internal readonly string Name;
            internal readonly int[] Scores = new int[5];
            internal int TotalScore
            {
                get { return Scores.OrderBy(sc => sc).Skip(1).Take(3).Sum(); }
            }
        }
        static void Main(string[] args)
        {
            string[] diverNames = File.ReadAllLines(@"F:\1 -C# Programming\Coursework\DiverName.txt");
            List<Diver> divers = new List<Diver>();
            for (int j = 0; j < 5; j++)
            {
                var diver = new Diver(diverNames[j]);
                for (int i = 0; i < 5; i++)
                {
                    int score;
                    do
                    {
                        Console.WriteLine("Please Enter a Score between 0 and 10 for {0}", diver.Name);
                        score = Convert.ToInt32(Console.ReadLine());
                    } while (score < 0 || score > 10);
                    diver.Scores[i] = score;
                    divers.Add(diver);
                }
            }
            var MaxScore = divers.Max(d => d.TotalScore);
            var Winner = divers.First(d => d.TotalScore == MaxScore);
            Console.WriteLine("The winner is {0} with score {1}", Winner.Name, MaxScore);        }
        }
      }
    }
