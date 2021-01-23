        private static IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> list, int length)
        {
            return length == 1 ? list.Select(t => new[] {t}) : GetPermutations(list, length - 1).SelectMany(t => list.Where(o => !t.Contains(o)), (t1, t2) => t1.Concat(new[] {t2}));
        }
        public static List<PlayerScore> TeamOfTheWeek(List<PlayerScore> playerList)
        {
            // Remove the players who scored 0 accross the board.
            playerList.RemoveAll(player => player.Forward + player.TallForward + player.Offensive + player.Defensive + player.OnBaller + player.Ruck == 0);
            // Rank each player score within a position.
            var forwardRank = playerList.RankByDescending(p => p.Forward, (p, r) => new {Rank = r, Player = p});
            var tallForwardRank = playerList.RankByDescending(p => p.TallForward, (p, r) => new {Rank = r, Player = p});
            var offensiveRank = playerList.RankByDescending(p => p.Offensive, (p, r) => new { Rank = r, Player = p });
            var defensiveRank = playerList.RankByDescending(p => p.Defensive, (p, r) => new { Rank = r, Player = p });
            var onBallerRank = playerList.RankByDescending(p => p.Defensive, (p, r) => new { Rank = r, Player = p });
            var ruckRank = playerList.RankByDescending(p => p.Ruck, (p, r) => new { Rank = r, Player = p });
            for (int i = playerList.Count - 1; i >= 0; i--)
            {
                //var rankName = forwardRank.First(x => x.Player.PlayerName == playerList[i].PlayerName).Player.PlayerName;
                var fw = forwardRank.First(x => x.Player.PlayerName == playerList[i].PlayerName).Rank;
                var tf = tallForwardRank.First(x => x.Player.PlayerName == playerList[i].PlayerName).Rank;
                var off = offensiveRank.First(x => x.Player.PlayerName == playerList[i].PlayerName).Rank;
                var def = defensiveRank.First(x => x.Player.PlayerName == playerList[i].PlayerName).Rank;
                var ob = onBallerRank.First(x => x.Player.PlayerName == playerList[i].PlayerName).Rank;
                var ruck = ruckRank.First(x => x.Player.PlayerName == playerList[i].PlayerName).Rank;
                if (fw >= 6 && tf >= 6 && off >= 6 && def >= 6 && ob >= 6 && ruck >= 6)
                {
                    // Player is outside top 6 for each position so remove, and reduce permutations.
                    playerList.RemoveAt(i);
                }
            }   
            // Now update the playerId as this is used to join back to the array later.
            var playerId = 0;
            foreach (var p in playerList.OrderBy(p => p.PlayerName))
            {
                p.Id = playerId;
                playerId = playerId + 1;
            }
            // Create and fill the position scores.
            List<int[]> positionScoreArray = new List<int[]>();
            foreach (var player in playerList.OrderBy(p => p.PlayerName))
            {
                // Player scored more than 0 so add to the positionScoreArray.
                int[] playerScores = { player.Forward, player.TallForward, player.Offensive, player.Defensive, player.OnBaller, player.Ruck };
                positionScoreArray.Add(playerScores);
            }
            // Players remaining in list pulled into array, ready for processing.
            string[] playerNameArray = playerList.OrderBy(x => x.PlayerName).Select(p => p.PlayerName).ToArray();
            // Load up the actual position scores to use in Parallel.For processing.
            for (int i = 0; i < playerNameArray.Length; i++)
            {
                for (int j = 0; j < positionScoreArray.Count; j++)
                {   
                    if (j == 0)
                    {
                        var player = playerList.FirstOrDefault(p => p.PlayerName == playerNameArray[i]);
                        if (player != null)
                            positionScoreArray[i][j] = player.Forward;
                    }
                    if (j == 1)
                    {
                        var player = playerList.FirstOrDefault(p => p.PlayerName == playerNameArray[i]);
                        if (player != null)
                            positionScoreArray[i][j] = player.TallForward;
                    }
                    if (j == 2)
                    {
                        var player = playerList.FirstOrDefault(p => p.PlayerName == playerNameArray[i]);
                        if (player != null)
                            positionScoreArray[i][j] = player.Offensive;
                    }
                    if (j == 3)
                    {
                        var player = playerList.FirstOrDefault(p => p.PlayerName == playerNameArray[i]);
                        if (player != null)
                            positionScoreArray[i][j] = player.Defensive;
                    }
                    if (j == 4)
                    {
                        var player = playerList.FirstOrDefault(p => p.PlayerName == playerNameArray[i]);
                        if (player != null)
                            positionScoreArray[i][j] = player.OnBaller;
                    }
                    if (j == 5)
                    {
                        var player = playerList.FirstOrDefault(p => p.PlayerName == playerNameArray[i]);
                        if (player != null)
                            positionScoreArray[i][j] = player.Ruck;
                    }
                }
            }
            Stopwatch parallelForEachStopWatch = new Stopwatch();
            parallelForEachStopWatch.Start();
            var count = 0;
            var playerIds = Enumerable.Range(0, playerNameArray.Length).ToList();
            var best = new { PlayerIds = new List<int>(), TeamScore = 0 };
            var positions = new[] { "FW", "TF", "Off", "Def", "OB", "Ruck" };
            // Thread safe the Parallel.ForEach
            lock (ThreadSafeObject)
            {
                Parallel.ForEach(GetPermutations(playerIds, positions.Length), perm =>
                    {
                        var teamScore = 0;
                        var players = perm.ToList();
                        for (int i = 0; i < positions.Length; i++) teamScore += positionScoreArray[players[i]][i];
                        if (teamScore > best.TeamScore) best = new {PlayerIds = players, TeamScore = teamScore};
                        if (count++%100000 == 0) Debug.WriteLine($"{count - 1:n0}");
                    }
                );
            }
            parallelForEachStopWatch.Stop();
            TimeSpan parallelForEach = parallelForEachStopWatch.Elapsed;
        
            Debug.WriteLine($"Parallel.ForEach (secs): {parallelForEach.Seconds}");
            Debug.WriteLine($"Permutations: {count:n0}");
            Debug.WriteLine($"Team Score: {best.TeamScore}");
            // Track Parallel.ForEach result.
            var tcTotwRequest = new TelemetryClient();
            tcTotwRequest.TrackEvent($"Permutations: {count:n0} Score: {best.TeamScore} Time (sec): {parallelForEach.Seconds}");
            lock (ThreadSafeObject)
            {
                if (best.PlayerIds.Count > 0)
                {
                    for (int i = 0; i < positions.Length; i++)
                    {
                        // Update the playerList, marking best players with TeamOfTheWeek position.
                        var player = playerList.FirstOrDefault(p => p.Id == best.PlayerIds[i]);
                        if (player != null)
                        {
                            player.TeamOfTheWeekPosition = positions[i];
                            player.TeamOfTheWeekScore = best.TeamScore;
                        }
                    }
                }
            }
            return playerList.OrderBy(p => p.PlayerName).ToList();
        }
    }
