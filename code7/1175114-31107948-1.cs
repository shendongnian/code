    public class TextFilter : IFilter
    {
       Func<object, string> Property;
       string Target { get; set; }
    
       public TextFilter(Func<object, string> property, string target)
       {
          Property = property;
          Target = target;
       }
    
       public bool Filter(object item)
       {
          return Property(item).Contains(Target);
        }
    }
