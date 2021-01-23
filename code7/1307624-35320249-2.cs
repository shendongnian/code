    public class MethodInterceptor<T> : Castle.DynamicProxy.IInterceptor {
        private T _returns;
        private string _methodName;
        public MethodInterceptor(string methodName, T returns) {
            _returns = returns;
            _methodName = methodName;
        }
        public void Intercept(IInvocation invocation) {
            if (invocation.Method.Name == _methodName) {
                invocation.ReturnValue = _returns;
            }
            else {
                invocation.Proceed();
            }
        }
    }
