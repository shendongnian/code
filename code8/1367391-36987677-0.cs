       public class Skier
        {
            public static Dictionary<string, Skier> Skiers = new Dictionary<string, Skier>();
            public int inScore { get; set; }
            public Skier()
            {
                int[] highscore = Skiers.AsEnumerable().OrderByDescending(x => ((Skier)x.Value).inScore).Take(3).Select(y => ((Skier)y).inScore).ToArray();
            }
        }
