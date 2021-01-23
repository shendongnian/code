            List<GameInfo> data = new List<GameInfo> { 
            new GameInfo { Game = "G1", Person = "A", Score = 10, EventTime = new DateTime(2014, 10, 10, 10, 10, 10) },
            new GameInfo { Game = "G1", Person = "A", Score = 10, EventTime = new DateTime(2014, 10, 10, 10, 10, 10) },
            new GameInfo { Game = "G2", Person = "B", Score = 11, EventTime = new DateTime(2014, 10, 10, 20, 10, 10) },
            new GameInfo { Game = "G2", Person = "B", Score = 11, EventTime = new DateTime(2014, 10, 10, 20, 10, 10) }
        };
            var q = from game in data
                    group game by new { G = game.Game, P = game.Person } into g
                    
                    select new {
                        Person = g.Key.P,
                        Game = g.Key.G,
                        Score = g.Where( o => o.EventTime == g.Max( x => x.EventTime ) ).First().Score
                    };
            foreach (var item in q)
            {
                Console.WriteLine("{0}, {1}, {2}", item.Game, item.Person, item.Score);
            }
