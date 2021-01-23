    public class Rule
    {
        public String atribute { get; set; }
        public String value { get; set; }
        public Rule() { }
        public Rule(String atribute, String value)
        {
            this.atribute = atribute;
            this.value = value;
        }
    }
    public class RuleObject
    {
        public Rule rule { get; set; }
        public List<int> indexList { get; set; }
        public RuleObject() { }
        public RuleObject(Rule rule, List<int> indexList)
        {
            this.rule = rule;
            this.indexList = indexList;
        }
    }
    public static class Program
    {
        public static void Main()
        {
            List<int> G = new List<int>() { 1, 2, 4, 5, 7 };
            List<RuleObject> ruleObjectList = new List<RuleObject>();
            ruleObjectList.Add(new RuleObject(new Rule("inflation", "decrease"), new List<int>() { 1, 2, 7 }));
            ruleObjectList.Add(new RuleObject(new Rule("inflation", "no_change"), new List<int>() { 3, 4, 5, 6, 8 }));
            ruleObjectList.Add(new RuleObject(new Rule("budget", "no_change"), new List<int>() { 1, 5, 8 }));
            ruleObjectList.Add(new RuleObject(new Rule("budget", "increase"), new List<int>() { 2, 3, 4, 6, 7 }));
            ruleObjectList.Add(new RuleObject(new Rule("reserve", "increase"), new List<int>() { 1, 3, 7, 8 }));
            ruleObjectList.Add(new RuleObject(new Rule("reserve", "decrease"), new List<int>() { 2, 4, 5 }));
            // See which rules are included and/or escluded form G.
            // Later we'll take the result based on this.
            var candidates = from r in ruleObjectList
                                 select new
                                 {
                                     rule = r.rule,
                                     contained = r.indexList.FindAll(num => G.Contains(num)),
                                     excluded = r.indexList.FindAll(num => !G.Contains(num))
                                 };
            // Take the ruleObject which has most values inside G and least values outside G.
            var result = candidates.OrderByDescending(c => c.contained.Count) // Order descending by contained rules in G
                                   .ThenBy(e => e.excluded.Count) // Then order ascending by excluded rules from G
                                   .FirstOrDefault(); // Take the element on top of the list, the result, or return null
                                                      // if there are no results.
            // Print final result.
            Console.WriteLine("Result is " + result?.rule.atribute + "-" + result?.rule.value);
        }
    }
