    public class PropertyBasedResolver : IValueResolver
    {
         public PropertyInfo Property { get; set; }
         public PropertyBasedResolver(PropertyInfo property)
         {
              this.Property = property;
         }
         public ResolutionResult Resolve(ResolutionResult source)
         {
               var result = GetValueFromKey(property, source.Value); // gets from some static cache or dictionary elsewhere in your code by reading the prop info and then using that to look up the value based on the key as appropriate
               return source.New(result)
         }
    }
