       public static IAsyncEnumerable<TState> Generate<TState>(TState initialState, Func<TState, bool> condition, Func<TState, Task<TState>> iterate)
        {
            return AsyncEnumerable.CreateEnumerable(() =>
            {
                var started = false;
                var current = default(TState);
                return AsyncEnumerable.CreateEnumerator(async c =>
                {
                    if (!started)
                    {
                        started = true;
                        var conditionMet = !c.IsCancellationRequested && condition(initialState);
                        if (conditionMet) current = initialState;
                        return conditionMet;
                    }
                    {
                        var newVal = await iterate(current).ConfigureAwait(false);
                        var conditionMet = !c.IsCancellationRequested && condition(newVal);
                        if (conditionMet) current = newVal;
                        return conditionMet;
                    }
                },
                    () => current,
                    () => { });
            });
        }
