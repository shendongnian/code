    public interface IConditionalSerializer
    {
        bool ShouldBeSerialized();
    }
    public static class FilteredSerializer
    {
        public static string SerializeConditional<T>(IEnumerable<T> input)
            where T : IConiditionalSerializer
        {
            return JsonConvert.SerializeObject(input.Where(e => e.ShouldBeSerialized()));
        }
    }
    public class Demo : IConditionalSerializer
    {
         public bool ShouldBeSerialized() => false;
    }
