    public static void Main() {
        var sample = new Baz<List<Foo>>();
        sample.DoSomething();
    }
    
    public class Foo { }
    
    public class Bar<T> {
        public void Boom() {
            Console.WriteLine("I am booming");
        }
    }
    
    
    public class Baz<T> {
        public void DoSomething() {
            var typeName = typeof(T).GetGenericArguments().Single().FullName;
            var type = Type.GetType(typeName);
            var genericRepoType = typeof(Bar<>);
            var specificRepoType = genericRepoType.MakeGenericType(new Type[] { type });
            dynamic genericBar = Activator.CreateInstance(specificRepoType);
            Console.WriteLine(genericBar.GetType().Name); 
                                                          
            genericBar.Boom();
        }
    }
