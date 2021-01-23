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
        public TaskAwaiter<T> GetAwaiter() 
        { 
            return Value.GetAwaiter(); 
        }
    }
