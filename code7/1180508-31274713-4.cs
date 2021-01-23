     interface IObjectParser {
         object Parse(object obj, propertyName string);
     }
     class ReflectionParser : IObjectParser {
         public object Parse(object obj, propertyName string) {
             return obj.GetType().GetProperty(propertyName).GetMethod().Invoke(obj);
         }
     }
     object parsedValue = new ReflectionParser().Parse(new MyClass(), "MyProperty");
    
