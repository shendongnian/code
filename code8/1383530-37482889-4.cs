    [Flags]
    public enum AgeCriterion
    {
       NotSpecified = 0,
       BelowTwentyFour = 1,
       TwentyToThirtyFive = 2,
       ThirtyToFourtyFive = 4,
       MoreThanFourtyFive = 8,
    }
    public class AgeCriterion
    {
        public AgeCriterion Age { get; set; }
    }
