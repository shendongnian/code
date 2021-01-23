    public class AsyncLazy<T> : Lazy<Task<T>>
    {
        public AsyncLazy(Func<T> valueFactory) :
            base(() => Task.Run(valueFactory))
        { 
        }
        public AsyncLazy(Func<Task<T>> taskFactory, bool runFactoryInNewTask = true) :
            base(() => runFactoryInNewTask ? Task.Run(taskFactory) : taskFactory())
        { 
        }
        //This lets you use `await _lazyData` instead of doing `await _lazyData.Value`
        public TaskAwaiter<T> GetAwaiter() 
        { 
            return Value.GetAwaiter(); 
        }
    }
