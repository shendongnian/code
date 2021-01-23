    public class BaseClass
    {
        public static T Create<T>(string optParam="whatever") where T : BaseClass
        {
            var t = new T(); //which invokes the paramterless constructor
            ((BaseClass)t).SomePropertyOrFieldInheritedFromTheBaseClass = optParam; //and then modifies the object however your BaseClass constructor was going to.
            return t;
        }
    }
