    private readonly int[] _playerRatings = new[] {1330, 1213, 1391, 1192, 1261, 1273, 1178, 1380, 1200, 1252};
    private int CalculateTeamScore(int team)
    {
        var score = 0;
        for (var i = 0; i < 10; ++i)
        {
            if ((team & 1) == 1)
            {
                score += _playerRatings[i];
            }
            team >>= 1;
        }
        return score;
    }
    private bool IsValidTeam(int team)
    {
        // determine how many bits are set, and return true if the result is 5
        // This is the slow way, but it works.
        var count = 0;
        for (var i = 0; i < 10; ++i)
        {
            if ((team & 1) == 1)
            {
                ++count;
            }
            team >>= 1;
        }
        return (count == 5);
    }
    public void Test()
    {
        // There are 10 players. You want 5-player teams.
        // Assign each player a bit position in a 10-bit number.
        // 2^10 is 1024.
        // Start counting at 0, and whenever you see a number that has 5 bits set,
        // you have a valid 5-player team.
        // If you invert the bits, you get the opposing team.
        // You only have to count up to 511 (2^9 - 1), because any team after that
        // will already have been found as the opposing team.
        for (var team = 0; team < 512; ++team)
        {
            if (IsValidTeam(team))
            {
                var opposingTeam = ~team;
                var teamScore = CalculateTeamScore(team);
                var opposingTeamScore = CalculateTeamScore(opposingTeam);
                var scoreDiff = Math.Abs(teamScore - opposingTeamScore);
                Console.WriteLine("{0}:{1} - {2}:{3} - Diff = {4}.", 
                    team, teamScore, opposingTeam, opposingTeamScore, scoreDiff);
            }
        }
    }
