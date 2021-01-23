    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace ConsoleApplication1
    {
        class Player
        {
            public int PlayerId { get; set; }
            public int PlayerBit { get; set; }
            public int PlayerScore { get; set; }
            public override string ToString()
            {
                return string.Format("Player: {0} Score: {1}\n",PlayerId,PlayerScore);
            }
        }
        public class Program
        {
            public static void Main(string[] args)
            {
                const int maxDiff = 15;
                var players = new List<Player> { new Player() {PlayerId = 1, PlayerBit = 1<<0, PlayerScore = 1330},
                                                 new Player() {PlayerId = 2, PlayerBit = 1<<1, PlayerScore = 1213},
                                                 new Player() {PlayerId = 3, PlayerBit = 1<<2, PlayerScore = 1391},
                                                 new Player() {PlayerId = 4, PlayerBit = 1<<3, PlayerScore = 1192},
                                                 new Player() {PlayerId = 5, PlayerBit = 1<<4, PlayerScore = 1261},
                                                 new Player() {PlayerId = 6, PlayerBit = 1<<5, PlayerScore = 1273},
                                                 new Player() {PlayerId = 7, PlayerBit = 1<<6, PlayerScore = 1178},
                                                 new Player() {PlayerId = 8, PlayerBit = 1<<7, PlayerScore = 1380},
                                                 new Player() {PlayerId = 9, PlayerBit = 1<<8, PlayerScore = 1200},
                                                 new Player() {PlayerId = 10, PlayerBit = 1<<9, PlayerScore = 1252}};
                var maxTeam = players.Max(x => x.PlayerBit);
                var maxBit = maxTeam * 2 - 1;
                var team = from t1 in Enumerable.Range(0, maxTeam) where getBitCount(t1) == 5 select t1;
                var match = team.Select(x => new { t1 = x, t2 = maxBit - x });
                foreach (var m in match)
                {
                    var t1 = players.Where(x => (x.PlayerBit & m.t1) == x.PlayerBit);
                    var t2 = players.Where(x => (x.PlayerBit & m.t2) == x.PlayerBit);
                    var t1Score = t1.Sum(x => x.PlayerScore);
                    var t2Score = t2.Sum(x => x.PlayerScore);
                    if (Math.Abs(t1Score - t2Score) < maxDiff)
                    {
                        Console.WriteLine("Team 1 total score {0} Team 2 total score {1}", t1Score, t2Score);
                        Console.WriteLine("{0} versu \n{1}\n\n", string.Join("", t1.Select(x => x.ToString()).ToArray()), string.Join("", t2.Select(x => x.ToString()).ToArray()));
                    }
                }
                Console.Read();
            }
            private static int getBitCount(int bits)
            {
                bits = bits - ((bits >> 1) & 0x55555555);
                bits = (bits & 0x33333333) + ((bits >> 2) & 0x33333333);
                return ((bits + (bits >> 4) & 0xf0f0f0f) * 0x1010101) >> 24;
            }
        }
    }
