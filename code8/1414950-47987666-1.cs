    public class TestMethodHandler : ICallHandler
    {
        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            IMethodReturn result = getNext()(input, getNext);
            //logic to check attribute values
            result.ReturnValue = input.Arguments[0] != input.Arguments[1];
            return result;
        }
    }
