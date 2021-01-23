    public interface IFilterable
    {
        string FilterProperty { get; }
    }
    public class A : IFilterable
    {
        //implementation
    }
    public class B : IFilterable
    {
        //Implementation
    }
    static IEnumerable<IFilterable> Filter(IEnumerable<IFilterable> source, string criteria)
    {
        foreach(var item in source)
        {
           if(item.FilterProperty.Contains(criteria)) yield return item;
        }
    }
