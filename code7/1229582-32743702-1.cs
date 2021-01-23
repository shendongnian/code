    public class MyClass {
        private enum Colours { Red, Green, Blue }
        private class Inner {
            private enum Colours { Black, White }
        }
    }
    class Program {
        static void Main(string[] args) {
            Type coloursType;
            // 1. enumerator
            coloursType = typeof(MyClass).EnumerateNestedTypes()
                .Where(t => t.Name == "Colours" && t.IsEnum)
                .FirstOrDefault();
            // 2. search method
            coloursType = typeof(MyClass).FindNestedType(t => t.Name == "Colours" && t.IsEnum);
            if(coloursType != null) {
                Console.WriteLine(string.Join(", ", coloursType.GetEnumNames()));
            } else {
                Console.WriteLine("Type not found");
            }
            Console.ReadKey();
        }
    }
    public static class Extensions {
      public static IEnumerable<Type> EnumerateNestedTypes(this Type type) {
            const BindingFlags flags = BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic;
            Queue<Type> toBeVisited = new Queue<Type>();
            toBeVisited.Enqueue(type);
            do {
                Type[] nestedTypes = toBeVisited.Dequeue().GetNestedTypes(flags);
                for(int i = 0, l = nestedTypes.Length; i < l; i++) {
                    Type t = nestedTypes[i];
                    yield return t;
                    toBeVisited.Enqueue(t);
                }
            } while(toBeVisited.Count != 0);
        }
        public static Type FindNestedType(this Type type, Predicate<Type> filter) {
            const BindingFlags flags = BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic;
            Type[] nestedTypes = type.GetNestedTypes(flags);
            foreach(var nestedType in nestedTypes) {
                if(filter(nestedType)) {
                    return nestedType;
                }
            }
            foreach(var nestedType in nestedTypes) {
                Type result = FindNestedType(nestedType, filter);
                if(result != null) {
                    return result;
                }
            }
            return null;
        }
    }
