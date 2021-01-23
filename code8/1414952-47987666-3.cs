    public class TestMethodHandler : ICallHandler
    {
        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            //manipulate with method here 
            //getNext is a method delegate 
            IMethodReturn result = getNext()(input, getNext);
            return result;
        }
    }
