    public class ConvertNotFoundInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            invocation.Proceed();
            var task = invocation.ReturnValue as Task;
            if (task != null)
                invocation.ReturnValue = ConvertNotFoundAsync((dynamic)task);
        }
        private static async Task ConvertNotFoundAsync(Task source)
        {
            try
            {
                await source.ConfigureAwait(false);
            }
            catch (InvalidOperationException)
            {
                throw new IndexOutOfRangeException();
            }
        }
        private static async Task<T> ConvertNotFoundAsync<T>(Task<T> source)
        {
            try
            {
                return await source.ConfigureAwait(false);
            }
            catch (InvalidOperationException)
            {
                throw new IndexOutOfRangeException();
            }
        }
    }
