    void Main()
    {
      var enumerable = default(IEnumerable<MyItem>);
      
      Search(enumerable, i => i.MyEnumerable);
      Search(enumerable, i => i.MyCollection);
    }
    
    public static IEnumerable<TSource> Search<TSource, TProperty>
      (
        IEnumerable<TSource> source, 
        Expression<Func<TSource, IEnumerable<TProperty>>> property)
    {
        return null;
    }
    
    public class MyItem
    {
      public IEnumerable<string> MyEnumerable { get; set; }
      public ICollection<string> MyCollection { get; set; }
    }
