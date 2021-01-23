    public class LoggingBehavior : IInterceptionBehavior
    {
        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            var next_bahavior = getNext();
            //Here do your logging before executing the method
            var method_return = next_bahavior.Invoke(input, getNext);
            //Here do your logging after executing the method
            return method_return;
        }
        public IEnumerable<Type> GetRequiredInterfaces()
        {
            yield break;
        }
        public bool WillExecute
        {
            get { return true; }
        }
    }
