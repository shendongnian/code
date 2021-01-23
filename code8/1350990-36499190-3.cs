    public interface IConiditionChecker
    {
        bool ShouldBeSerialized(object instance);
    }
    public class ConditionAttribute : Attribute
    {
        public Type ConditionChecker { get; set; }
    }
    public static class FilteredSerializer
    {
        public static string SerializeConditional(IEnumerable<object> input)
        {
            var matches = (from entry in input
                           let att = entry.GetType().GetCustomAttribute<ConditionAttribute>()
                           let hasChecker = att != null && att.ConditionChecker != null
                           let checker = hasChecker ? (IConiditionChecker)Activator.CreateInstance(att.ConditionChecker) : null
                           where checker.ShouldBeSerialized(entry)
                           select entry);
            return JsonConvert.SerializeObject(matches);
        }
    }
    [Condition(ConditionChecker = typeof(SomeChecker))]
    public class Demo
    {
    }
