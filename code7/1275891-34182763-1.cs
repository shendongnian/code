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
    //Declaring Filter as extension method is possible aswell:
    //static IEnumerable<T> Filter(this IEnumerable<T> source, string criteria) 
    static IEnumerable<T> Filter(IEnumerable<T> source, string criteria) 
           where T : IFilterable
    {
        foreach(var item in source)
        {
           if(item.FilterProperty.Contains(criteria)) yield return item;
        }
    }
