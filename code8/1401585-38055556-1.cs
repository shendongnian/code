    public class MyOrderRuleComparer : EqualityComparer<OrderRule>
    {
        private IEqualityComparer<string> _c = EqualityComparer<string>.Default;
        public override bool Equals(OrderRule l, OrderRule r)
        {
            return _c.Equals(l.Property, r.Property);
        }
        public override int GetHashCode(OrderRule rule)
        {
            return _c.GetHashCode(rule.Property);
        }
    }
...
    HashSet<OrderRule> rules = new HashSet(new MyOrderRuleComparer());
