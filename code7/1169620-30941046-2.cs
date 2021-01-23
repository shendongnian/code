    class Program
    {
        static void Main(string[] args)
        {
            List<int?> intList = new List<int?>() { 3, 4};
            List<RuleModel> Rules = new List<RuleModel>();
            Rules.Add(new RuleModel{Name = "Rule1", Rule = (i => i == 1)});
            Rules.Add(new RuleModel{Name = "Rule2", Rule = (i => i == 2)});
            Rules.Add(new RuleModel{Name = "Rule3", Rule = (i => i == 3)});
            Rules.Add(new RuleModel{Name = "Rule4", Rule = (i => i == 4)});
            int? valueToSet = null;
            var ruleUsed = Rules.FirstOrDefault(r => (valueToSet = intList.FirstOrDefault(r.Rule)) != null);
        }
    }
    public class RuleModel
    {
        public Func<int?, bool> Rule { get; set; }
        public string Name { get; set; }
    }
