    public class RuleTimeDecorator : IRule
    {
        private readonly IRule _decoratedRule;
    
        public RuleTimeDecorator(IRule decoratedRule)
        {
            _decoratedRule = decoratedRule;
        }
    
        public string GetResult(int input)
        {
            var result = _decoratedRule.GetResult(input);
            
            return IsMidnight()? $"{result} ***" : result;
        }
        
        private bool IsMidnight() => //here goes the code to check if current time meets criteria 
    }
