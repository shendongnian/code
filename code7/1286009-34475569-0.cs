    public static class RepeatForEach<T>
    {
        public static Action<Action<T>, IEnumerable<T>> Action = (action, enumerable)
        {
            foreach (var element in enumerable)
            {
                action.Invoke(element);
            }
        }
    }
