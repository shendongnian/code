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
        }
        class Program
        {
            static void Main(string[] args)
            {
                const int maxDiff = 1;
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
                //combinations
                var teams = from p1 in players
                            from p2 in players
                            where p1.PlayerId != p2.PlayerId
                            select new
                            {
                                player1 = p1.PlayerId,
                                player2 = p2.PlayerId,
                                playersBit = p1.PlayerBit | p2.PlayerBit,
                                totalScore = p1.PlayerScore + p2.PlayerScore
                            };
                //matching team
                var result = (from t1 in teams
                              from t2 in teams
                              where (t1.playersBit & t2.playersBit) == 0 &&
                                   Math.Abs(t1.totalScore - t2.totalScore) <= maxDiff
                              select new { t1, t2 });
                foreach (var t in result)
                    Console.WriteLine(t);
                Console.Read();
            }
        }
    }
