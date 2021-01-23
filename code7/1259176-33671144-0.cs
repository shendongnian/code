    public class ClassNameBuilder
    {
        //default constructor;
        //store params in private fields
        public ClassName(string enumValue, string user, string custom_class) { } 
        
        public ClassName BuildClassName()
        {
            return new ClassName(EnumToString, new User(user), new CustomClass(custom_class));
        }
    }
