    // create MyResourceProvider.resx to auto generate this class in MyResourceProvider.Designer.cs,
    // or create class manually and specify messages in code
    public class MyResourceProvider {
       public static string greaterthan_error {
          get { 
              return "{PropertyName} should be greater than {ComparisonValue}, but you entered {PropertyValue}";
          }
       }
       public static string lessthan_error {
          get { 
              return "{PropertyName} should be less than {ComparisonValue}";
          }
       }
    }
