    // It's an OVERSIMPLIFICATION, but it should give you the hint
    // to keep you in the right track...
    // This code requires C# 6 as it's using expression-bodied properties!
    public class DomainResult<TResult>
    {
        public TResult Result { get; set; }
        public List<BrokenRule> BrokenRules { get; } = new List<BrokenRule>();
        public bool IsSuccessful => BrokenRules.Count == 0;
    } 
