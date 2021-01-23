    public sealed class GradeBand
    {
        public int MinScore { get; }
        public int MaxScore { get; } // Note: inclusive!
        public decimal Grade { get; }
        public GradeBand(int minScore, int maxScore, decimal grade)
        {
            // TODO: Validation
            MinScore = minScore;
            MaxScore = maxScore;
            Grade = grade;
        }
    }
