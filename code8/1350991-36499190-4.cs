    public interface IShouldBeSerialized
    {
        bool ShouldBeSerialized();
    }
    public static class FilteredSerializer
    {
        public static string SerializeConditional(IEnumerable<object> input)
        {
            var matches = (from entry in input
                           let casted = entry as IShouldBeSerialized
                           where casted == null || casted.ShouldBeSerialized()
                           select entry);
            return JsonConvert.SerializeObject(matches);
        }
    }
    public class Demo : IShouldBeSerialized
    {
        public bool ShouldBeSerialized()
        {
            return false;
        }
    }
