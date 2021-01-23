    public interface IDetail<T>
    {
        
    }
    public interface IMaster<T>
    {
        
    }
    public class MyClass
    {
        public void method()
        {
            Principal aPrincipal = new Principal();
            aPrincipal.Permissions.Foreach(x => aPrincipal.RemoveDetail(x)); // No suggestion from resharper
        }
    }
    public class Permission : IDetail<Principal>
    {
    }
    public class Principal : IMaster<Permission>
    {
        public virtual IEnumerable<Permission> Permissions { get { throw new NotImplementedException(); }  }
    }
    public static class Class
    {
        public static void RemoveDetail<TMaster, TChild>(this TMaster master, TChild child)
            where TMaster : class, IMaster<TChild>
            where TChild : class, IDetail<TMaster>
        {
            
        }
        public static void Foreach<T>(this IEnumerable<T> source, Action<T> action)
        {
            
        }
    }
