    public class RetryExecution<T>
    {
        private readonly Func<T> _function;
        private List<Exception> _exceptions = new List<Exception>();
        public RetryExecution(Expression<Func<T>> expression )
        {
            _function = expression.Compile();
        }
        public Exception[] Exceptions { get { return _exceptions.ToArray(); } }
        public T Execute(int maxAttempts)
        {
            var attempts = 0;
            while (attempts < maxAttempts)
            {
                attempts++;
                try
                {
                    return _function.Invoke();
                }
                catch (Exception ex)
                {
                    if (attempts >= maxAttempts) throw;
                    _exceptions.Add(ex);
                }
            }
            return default(T);//Not reachable, but compiler needs it.
        }
    }
