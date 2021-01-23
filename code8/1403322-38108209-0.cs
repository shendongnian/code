    public static class ObjectExtension
    {
        public static List<T> Sort<T>(this List<T> list) where T : IFoo
        {
            list.Sort((x, y) => string.Compare(x.Name, y.Name));
    		return list;
        }
    }
    
    public interface IFoo {
    	string Name { get; }
    }
    
    public class Foo1 {
    	public string Name { get; set; }
    }
    
    public class Foo2 {
    	public string Name { get; set; }
    }
