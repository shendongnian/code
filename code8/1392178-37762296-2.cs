    public class ImportAttribute : Attribute { }
    class UnityDependencyPropertySelectionBehavior : IPropertySelectionBehavior 
    {
         public bool SelectProperty(Type type, PropertyInfo prop) 
         {
             return prop.GetCustomAttributes(typeof(DependencyAttribute)).Any();
         }
    }
