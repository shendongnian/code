    // Just a container to conveniently hold a match between two teams
    public class Match
    {
        public Match(string teamOne, string teamTwo)
        {
            TeamOne = teamOne;
            TeamTwo = teamTwo;
        }
        public string TeamOne { get; private set; }
        public string TeamTwo { get; private set; }
        public override string ToString()
        {
            return String.Format("{0} vs {1}", TeamOne, TeamTwo);
        }
    }
    public class MatchMaking
    {
        public MatchMaking()
        {
            Teams = new List<string> { "A", "B", "C", "D", "E" };
        }
        public IList<string> Teams { get; private set; }
        public IList<Match> GetMatches()
        {
            var unorderedMatches = GetUnorderedMatches();
            // The list that we will eventually return
            var orderedMatches = new List<Match>();
            // Track the most recently added match
            Match lastAdded = null;
            // Loop through the unordered matches
            // Add items to the ordered matches
            // Add the one that is most different from the last added match
            for (var i = 0; i < unorderedMatches.Count; i++)
            {
                if (lastAdded == null)
                {
                    lastAdded = unorderedMatches[i];
                    orderedMatches.Add(unorderedMatches[i]);
                    unorderedMatches[i] = null;
                    continue;
                }
                var remainingMatches = unorderedMatches.Where(m => m != null);
                // Get the match which is the most different from the last added match
                // We do this by examining all of the unadded matches and getting the maximum difference
                Match mostDifferentFromLastAdded = null;
                int greatestDifference = 0;
                foreach (var match in remainingMatches)
                {
                    var difference = GetDifference(lastAdded, match);
                    if (difference > greatestDifference)
                    {
                        greatestDifference = difference;
                        mostDifferentFromLastAdded = match;
                    }
                    if (difference == 2)
                    {
                        break;
                    }
                }
                // Add the most different match
                var index = unorderedMatches.ToList().IndexOf(mostDifferentFromLastAdded);
                lastAdded = unorderedMatches[index];
                orderedMatches.Add(unorderedMatches[index]);
                unorderedMatches[index] = null;
            }
            return orderedMatches;
        }
        // Create a list containing the total match combinations with an arbitrary order
        private List<Match> GetUnorderedMatches()
        {
            var totalNumberOfCombinations = AdditionFactorial(Teams.Count - 1);
            var unorderedMatches = new List<Match>(totalNumberOfCombinations);
            for (int i = 0; i < Teams.Count; i++)
            {
                for (int j = 0; j < Teams.Count; j++)
                {
                    if (j <= i) continue;
                    unorderedMatches.Add(new Match(Teams[i], Teams[j]));
                }
            }
            return unorderedMatches;
        }
        // Get the difference between two matches
        // 0 - no difference, 1 - only one team different, 2 - both teams different
        private int GetDifference(Match matchOne, Match matchTwo)
        {
            var matchOneTeams = new HashSet<string> { matchOne.TeamOne, matchOne.TeamTwo };
            var matchTwoTeams = new HashSet<string> { matchTwo.TeamOne, matchTwo.TeamTwo };
            var intersection = matchOneTeams.Intersect(matchTwoTeams);
            return (intersection.Count() - 2) * -1;
        }
        // Just a helper to get the total number of match combinations
        private int AdditionFactorial(int seed)
        {
            int result = 0;
            for (int i = seed; i > 0; i--)
            {
                result += i;
            }
            return result;
        }
    }
    public class Program
    {
        private static void Main(string[] args)
        {
            var matchMaking = new MatchMaking();
            foreach (var match in matchMaking.GetMatches())
            {
                Console.WriteLine(match);
            }
        }
    }
