    public class Duck
    {
        public void Quack()
        {
            Console.WriteLine("Quack Quack!");
        }
    
        public void Swim()
        {
            Console.WriteLine("Swimming...");
        }
    }
    
    public interface IQuack
    {
        void Quack();
    }
    
    public interface ISwimmer
    {
        void Swim();
    }
    
    public static class DuckTypingExtensions
    {
        private static readonly ProxyGenerator generator = new ProxyGenerator();
    
        public static T As<T>(this object o)
        {
            return generator.CreateInterfaceProxyWithoutTarget<T>(new DuckTypingInterceptor(o));
        }
    }
    
    public class DuckTypingInterceptor : IInterceptor
    {
        private readonly object target;
    
        public DuckTypingInterceptor(object target)
        {
            this.target = target;
        }
    
        public void Intercept(IInvocation invocation)
        {
            var methods = target.GetType().GetMethods()
                .Where(m => m.Name == invocation.Method.Name)
                .Where(m => m.GetParameters().Length == invocation.Arguments.Length)
                .ToList();
            if (methods.Count > 1)
                throw new ApplicationException(string.Format("Ambiguous method match for '{0}'", invocation.Method.Name));
            if (methods.Count == 0)
                throw new ApplicationException(string.Format("No method '{0}' found", invocation.Method.Name));
            var method = methods[0];
            if (invocation.GenericArguments != null && invocation.GenericArguments.Length > 0)
                method = method.MakeGenericMethod(invocation.GenericArguments);
            invocation.ReturnValue = method.Invoke(target, invocation.Arguments);
        }
    }
