     [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
     public sealed class MyPropertyAliasAttribute: Attribute {
       public String Alias {get; private set; }
       public MyPropertyAliasAttribute(String alias) {
         Alias = alias;
       }
     }
