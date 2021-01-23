    public class ImportAttribute : Attribute { }
    class ImportPropertySelectionBehavior : IPropertySelectionBehavior 
    {
         public bool SelectProperty(Type type, PropertyInfo prop) 
         {
             return prop.GetCustomAttributes(typeof(ImportAttribute)).Any();
         }
    }
