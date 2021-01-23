    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication1
    {
        class Program
        {
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
            public static void Main(string[] args)
            {
                List<int> G = new List<int>() { 1, 2, 4, 5, 7 };
                List<RuleObject> ruleObjectList = new List<RuleObject>();
                ruleObjectList.Add(new RuleObject(new Rule("inflation", "decrease"), new List<int>() { 1, 2, 7 }));
                ruleObjectList.Add(new RuleObject(new Rule("inflation", "no_change"), new List<int>() { 3, 4, 5, 6, 8 }));
                ruleObjectList.Add(new RuleObject(new Rule("budget", "no_change"), new List<int>() { 1, 5, 8 }));
                ruleObjectList.Add(new RuleObject(new Rule("budget", "increase"), new List<int>() { 2, 3, 4, 6, 7 }));
                ruleObjectList.Add(new RuleObject(new Rule("reserve", "increase"), new List<int>() { 1, 3, 7, 8 }));
                ruleObjectList.Add(new RuleObject(new Rule("reserve", "decrease"), new List<int>() { 2, 4, 5 }));
                var results = ruleObjectList.Where(x => x.indexList.Where(y => G.Contains(y)).Count() == 3).ToList();
            }
        }
    }
    ​
