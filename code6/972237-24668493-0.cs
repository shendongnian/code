    namespace CSharpWPF
    {
        public abstract class BaseFilter
        {
            //public abstract bool ApplyFilter();
        }
        public class PropertyFilter : BaseFilter
        {
            public string PropertyName { get; set; }
            public Type PropertyType { get; set; }
            public ConditionalOperator Operator { get; set; }
            public Filter Filter { get; set; }
        }
        public class FilterGroup : BaseFilter
        {
            public FilterGroup()
            {
                Filters = new List<BaseFilter>();
            }
            public ConditionalOperator? Operator { get; set; }
            public List<BaseFilter> Filters { get; set; }
        }
        public enum ComparisonOperator
        {
            Equals,
            Contains,
            StartsWith,
            EndsWith
        }
        public enum ConditionalOperator
        {
            And,
            Or
        }
        public class Filter
        {
            public ComparisonOperator Operator { get; set; }
            public string Value { get; set; }
            public bool MatchCase { get; set; }
        }
    }
