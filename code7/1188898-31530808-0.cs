    public static class Program {
        static void Main(string[] args) {
            var items = Assembly.GetExecutingAssembly().GetTypes()
                                .Where(x => !x.IsAbstract && x.GetBaseTypes().Contains(typeof(Item)));
                                
                                
        }
        public static IEnumerable<Type> GetBaseTypes(this Type type) {
            if (type.BaseType == null) return type.GetInterfaces();
            return Enumerable.Repeat(type.BaseType, 1)
                             .Concat(type.GetInterfaces())
                             .Concat(type.GetInterfaces().SelectMany<Type, Type>(GetBaseTypes))
                             .Concat(type.BaseType.GetBaseTypes());
        }
    }
    public class Item { }
    public class ItemA : Item { }
    public class ItemB : ItemA { }
    public abstract class ItemC : Item { }
