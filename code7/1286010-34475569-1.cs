    public static class MyClass
    {
        public static Action<Action<T>, IEnumerable<T>> GetRepeatForEachAction<T>()
        { 
            return (action, enumerable) =>
            {
                foreach (var element in enumerable)
                {
                    action.Invoke(element);
                }
            }
        }
    }
