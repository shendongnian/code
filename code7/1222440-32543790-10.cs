    public class OurFramework
    {
        string rules;        
        public void SetRules(string rules)
        {
            this.rules = rules;
        }
        public bool IsValid(string input)
        {
            if (!string.IsNullOrEmpty(rules)
            {
                return input == rules; //valid state is when the input is the same as the rules
            }
            else
            {
                throw new OurFrameworkInvalidOperationException("specify rules first");
            }
        }
    }
